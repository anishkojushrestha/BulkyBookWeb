using BulkyBookWeb.Data;
using BulkyBookWeb.Data.Repository;
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

        public Product Product { get; private set; }

        public ProductController(IUnitOfWork _db, IWebHostEnvironment webHostEnvironment)
        {
            this._db = _db;
            this.webHostEnvironment = webHostEnvironment;   
        }

        public async Task<IActionResult> Index()
        {
            
            IEnumerable<Product> data = _db.Product.GetAll(includeProperties: "Category,CoverType");
            return View(data);
        }
        public async Task<IActionResult> Create(int? id)
        {
            //Product product = new();
            //IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
            //    u=> new SelectListItem
            //    {
            //        Text=u.Name,
            //        Value=u.Id.ToString(),
            //    }
            //    );

            //IEnumerable<SelectListItem> CoverTypeList = _db.CoverType.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString(),
            //    }
            //    );
            //if(id==null || id == 0)
            //{
            //    ViewBag.CategoryList = CategoryList;
            //    ViewBag.CoverTypeList = CoverTypeList;
            //    return View(product);
            //}

            //Product = _db.Product.GetFirstOrDefault(u => u.Id == id);
            ViewData["CategoryId"] = new SelectList(await _db.Category.GetAllAsync(), "Id", "Name");
            ViewData["CoverTypeId"] = new SelectList(await _db.CoverType.GetAllAsync(), "Id", "Name");
            return View();
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
                TempData["Success"] = "Category Added successfuly";
                return RedirectToAction("Index");

            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _db.Product.GetByIdAsync(id);
            if(data == null)
            {
                return View(NotFound());
            }
            ViewData["CategoryId"] = new SelectList(await _db.Category.GetAllAsync(), "Id", "Name", data.CategoryId);
            ViewData["CoverTypeId"] = new SelectList(await _db.CoverType.GetAllAsync(), "Id", "Name", data.CoverTypeId);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string path = webHostEnvironment.WebRootPath;
                if (path != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(path, @"img/");
                    var extension = Path.GetExtension(file.FileName);
                    using (var fileStreams = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    product.Image = @"\img\" + fileName + extension;

                }

                await _db.Product.UpdateAsync(id, product);
                TempData["Success"] = "Category Updated successfuly";
                return RedirectToAction("Index");

            }

            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Product.GetByIdAsync(id);
            if (data != null)
            {
                await _db.Product.DeleteAsync(id);

                TempData["Success"] = "Category Deleted successfuly";
                return RedirectToAction("Index");
            }
            return View(data);
        }
        //#region API CALL
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var productList = _db.Product.GetAll(includeProperties:"Category,CoverType");
        //    return Json(new { data = productList });
        //}
        //#endregion
    }
    }
