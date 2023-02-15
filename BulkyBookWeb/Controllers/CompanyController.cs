using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _db;

        public CompanyController(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> data = await _db.Company.GetAllAsync();
            return View(data);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _db.Company.AddAsync(company);
                TempData["Success"] = "Category created successfuly";
                return RedirectToAction("Index");

            }

            return View(company);
        }
        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _db.Company.GetByIdAsync(id);
            if (data == null)
            {
                return View(NotFound());
            }
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (ModelState.IsValid)
            {
                await _db.Company.UpdateAsync(id, company);
                TempData["Success"] = "Category Updated successfuly";
                return RedirectToAction("Index");

            }

            return View(company);
        }
        //GET
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Company.GetByIdAsync(id);
            if (data != null)
            {
                await _db.Company.DeleteAsync(id);

                TempData["Success"] = "Category Deleted successfuly";
                return RedirectToAction("Index");
            }
            return View(data);
        }
    }
}
