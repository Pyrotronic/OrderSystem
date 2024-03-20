using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext db;
        public EmployeeController(AppDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(SortState sortState = SortState.Id_employeeASC)
        {
            IQueryable<Employees>? employees = db.Employees;
            ViewData["Id_employeeSort"] = sortState == SortState.Id_employeeASC ? SortState.Id_employeeDESC : SortState.Id_employeeASC;
            ViewData["SurnameSort"] = sortState == SortState.SurnameASC ? SortState.SurnameDESC : SortState.SurnameASC;
            ViewData["NameSort"] = sortState == SortState.NameASC ? SortState.NameDESC : SortState.NameASC;
            

            employees = sortState switch
            {
                SortState.Id_employeeDESC => employees.OrderByDescending(s => s.Id_employee),
                SortState.SurnameASC => employees.OrderBy(s => s.Surname),
                SortState.SurnameDESC => employees.OrderByDescending(s => s.Surname),
                SortState.NameASC => employees.OrderBy(s => s.Name),
                SortState.NameDESC => employees.OrderByDescending(s => s.Name),
                
                _ => employees.OrderBy(s => s.Id_employee),
            };
            return View(await employees.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employees employees)
        {
            db.Employees.Add(employees);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete()
        {
            return View(await db.Employees.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id_employee)
        {
            var employee = await db.Employees.FindAsync(Id_employee);
            if (Id_employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Employees? employee = await db.Employees.FirstOrDefaultAsync(p => p.Id_employee == id);
                if (employee != null) return View(employee);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employees employee)
        {
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
