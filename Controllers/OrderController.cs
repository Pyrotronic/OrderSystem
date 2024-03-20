using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class OrderController : Controller
    {
        AppDbContext db;
        public OrderController(AppDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Client = db.Client.ToList();
            ViewBag.Employee = db.Employees.ToList();
            return View(await db.Order.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Client = db.Client.ToList();
            ViewBag.Employee = db.Employees.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            db.Order.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id_Order)
        {

            var order = await db.Order.FindAsync(Id_Order);
            if (Id_Order != null)
            {
                db.Order.Remove(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete()
        {
            ViewBag.Client = db.Client.ToList();
            ViewBag.Employee = db.Employees.ToList();
            return View(await db.Order.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Client = db.Client.ToList();
            ViewBag.Employee = db.Employees.ToList();
            if (id != null)
            {
                Order? order = await db.Order.FirstOrDefaultAsync(p => p.Id_Order == id);
                if (order != null) return View(order);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            db.Order.Update(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Details(int? id)
        {
            ViewBag.Product = db.Product.ToList();
            var nakladnayaItems = db.Nakladnaya
                .Where(n => n.Id_Order == id)
                .ToList();
            return View(nakladnayaItems);
        }
    }
}
