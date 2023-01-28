using BulkyBookWeb.Data;
using BulkyBookWeb.Data.Services;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _db;

        public CategoryController(ICategoryServices _db)
        {
            this._db = _db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> data = await _db.GetAllAsync();
            return View(data);
        }

        //GET
        public IActionResult Create() {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) {
            if(ModelState.IsValid)
            {
                await _db.AddAsync(category);

                TempData["Success"] = "Category created successfuly";
                return RedirectToAction("Index");

            }
            
            return View(category);
        }
        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _db.GetByIdAsync(id);  
            if (data == null)
            {
                return View(NotFound());
            }
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                await _db.UpdateAsync(id, category);

                TempData["Success"] = "Category Updated successfuly";
                return RedirectToAction("Index");

            }

            return View(category);
        }
        //GET
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.GetByIdAsync(id);
            if (data != null)
            {
                await _db.DeleteAsync(id);
                TempData["Success"] = "Category Deleted successfuly";
                return RedirectToAction("Index");
            }
            return View(data);
        }
    }
}
