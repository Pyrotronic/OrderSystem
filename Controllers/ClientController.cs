using Microsoft.AspNetCore.Mvc;
using OrderSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace OrderSystem.Controllers
{
    public class ClientController : Controller
    {
        AppDbContext db;
        public ClientController(AppDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(SortState sortState = SortState.id_ClientASC)
        {
            IQueryable<Client>? clients = db.Client;
            ViewData["id_ClientSort"] = sortState == SortState.id_ClientASC ? SortState.id_ClientDESC : SortState.id_ClientASC;
            ViewData["SurnameSort"] = sortState == SortState.SurnameASC ? SortState.SurnameDESC : SortState.SurnameASC;
            ViewData["NameSort"] = sortState == SortState.NameASC ? SortState.NameDESC : SortState.NameASC;
            ViewData["AddressSort"] = sortState == SortState.AddressASC ? SortState.AddressDESC : SortState.AddressASC;

            clients = sortState switch
            {
                SortState.id_ClientDESC => clients.OrderByDescending(s => s.id_Client),
                SortState.SurnameASC => clients.OrderBy(s => s.Surname),
                SortState.SurnameDESC => clients.OrderByDescending(s => s.Surname),
                SortState.NameASC => clients.OrderBy(s => s.Name),
                SortState.NameDESC => clients.OrderByDescending(s => s.Name),
                SortState.AddressASC => clients.OrderBy(s => s.Address),
                SortState.AddressDESC => clients.OrderByDescending(s => s.Address),
                _ => clients.OrderBy(s => s.id_Client),
            };
            return View(await clients.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client Client)
        {
            db.Client.Add(Client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id_Client)
        {
            var client = await db.Client.FindAsync(id_Client);
            if (id_Client != null)
            {
                db.Client.Remove(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete()
        {
            return View(await db.Client.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Client? client = await db.Client.FirstOrDefaultAsync(p => p.id_Client == id);
                if (client != null) return View(client);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            db.Client.Update(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
