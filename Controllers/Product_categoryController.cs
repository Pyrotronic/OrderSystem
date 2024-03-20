using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class Product_categoryController : Controller
    {
        AppDbContext db;
        public Product_categoryController(AppDbContext context)
        {
            db = context;   
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Product_category.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product_category category) 
        {
            db.Product_category.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id_PC)
        {
            var category = await db.Product_category.FindAsync(Id_PC);
            if (Id_PC != null)
            {
                db.Product_category.Remove(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete()
        {
            return View(await db.Product_category.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product_category? category = await db.Product_category.FirstOrDefaultAsync(p => p.Id_PC == id);
                if (category != null) return View(category);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product_category category)
        {
            db.Product_category.Update(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
