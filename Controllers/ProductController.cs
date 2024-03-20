using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext db;
        public ProductController(AppDbContext context)
        { 
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Product_category = db.Product_category.ToList();
            return View(await db.Product.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Product_category = db.Product_category.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Product.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id_product)
        {

            var product = await db.Product.FindAsync(Id_product);
            if (Id_product != null)
            {
                db.Product.Remove(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete()
        {
            return View(await db.Product.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Product_category = db.Product_category.ToList();
            if (id != null)
            {
                Product? product = await db.Product.FirstOrDefaultAsync(p => p.Id_product == id);
                if (product != null) return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            db.Product.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
