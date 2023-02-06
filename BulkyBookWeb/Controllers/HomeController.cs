using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;
       

        public HomeController(ILogger<HomeController> logger, IUnitOfWork _db)
        {
            _logger = logger;
            this._db = _db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Product> data = _db.Product.GetAll(includeProperties: "Category,CoverType");
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}