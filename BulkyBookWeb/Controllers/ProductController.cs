using BulkyBookWeb.Data;
using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nest;
using System.Linq.Expressions;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork _db, IWebHostEnvironment webHostEnvironment)
        {
            this._db = _db;
            this.webHostEnvironment = webHostEnvironment;   
        }

        public async Task<IActionResult> Index()
        {
            //IEnumerable<Product> data = await _db.Product.GetAllAsync();
            return View();
        }
        public IActionResult Create(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
                u=> new SelectListItem
                {
                    Text=u.Name,
                    Value=u.Id.ToString(),
                }
                );
            
            IEnumerable<SelectListItem> CoverTypeList = _db.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }
                );
            if(id==null || id == 0)
            {
                ViewBag.CategoryList = CategoryList;
                ViewBag.CoverTypeList = CoverTypeList;
            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile? file) 
        {
            if(ModelState.IsValid)
            {
                string path = webHostEnvironment.WebRootPath;
                if(path != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(path, @"img/");
                    var extension = Path.GetExtension(file.FileName);
                    using (var fileStreams = new FileStream(Path.Combine(upload,fileName+extension),FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    product.Image = @"\img\" + fileName + extension; 

                }
                await _db.Product.AddAsync(product);
                return RedirectToAction("Index");

            }

            return View(product);
        }
        public async Task<IActionResult> Edit()
        {
            ViewData["CoverTypeId"] = new SelectList(await _db.Product.GetAllAsync(), "CoverTypeId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _db.Product.AddAsync(product);
                return RedirectToAction("Index");

            }

            return View(product);
        }
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _db.Product.GetAll();
            return Json(new { data = productList });
        }
        #endregion
    }
}
