using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace BulkyBookWeb.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;

        public CoverTypeController(IUnitOfWork _db)
        {
            this._db = _db;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CoverType> data = await _db.CoverType.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoverType covertype)
        {
            if (ModelState.IsValid)
            {
                await _db.CoverType.AddAsync(covertype);

                TempData["Success"] = "Category created successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(covertype);
        }
        public async Task< IActionResult> Edit(int id)
        {
            var data = await _db.CoverType.GetByIdAsync(id);
            if (data == null)
            {
                return View(NotFound());
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CoverType covertype)
        {
            if (ModelState.IsValid)
            {
                await _db.CoverType.UpdateAsync(id, covertype);

                TempData["Success"] = "Category Updated successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(covertype);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = _db.CoverType.GetByIdAsync(id);
            if(data == null)
            {
                return View(data);
            }
            await _db.CoverType.DeleteAsync(id);
            TempData["Success"] = "Category Deleted successfuly";
            return RedirectToAction(nameof(Index));
        }
    }

}
