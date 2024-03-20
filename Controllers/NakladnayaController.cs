using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class NakladnayaController : Controller
    {
        AppDbContext db;
        public NakladnayaController(AppDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Order = db.Order.ToList();
            ViewBag.Product = db.Product.ToList();
            return View(await db.Nakladnaya.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Order = db.Order.ToList();
            ViewBag.Product = db.Product.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Nakladnaya nakladnaya)
        {
            var product = await db.Product.FindAsync(nakladnaya.Id_product);
            nakladnaya.Summa = nakladnaya.Amount * product.Price;
            db.Nakladnaya.Add(nakladnaya);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id_nakladnaya)
        {

            var nakladnaya = await db.Nakladnaya.FindAsync(Id_nakladnaya);
            if (Id_nakladnaya != null)
            {
                db.Nakladnaya.Remove(nakladnaya);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete()
        {
            ViewBag.Order = db.Order.ToList();
            ViewBag.Product = db.Product.ToList();
            return View(await db.Nakladnaya.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Order = db.Order.ToList();
            ViewBag.Product = db.Product.ToList();
            if (id != null)
            {
                Nakladnaya? nakladnaya = await db.Nakladnaya.FirstOrDefaultAsync(p => p.Id_nakladnaya == id);
                if (nakladnaya != null) return View(nakladnaya);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Nakladnaya nakladnaya)
        {
            var product = await db.Product.FindAsync(nakladnaya.Id_product);
            nakladnaya.Summa = nakladnaya.Amount * product.Price;
            db.Nakladnaya.Update(nakladnaya);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

