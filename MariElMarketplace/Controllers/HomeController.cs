using Microsoft.Extensions.Logging;
using MariElMarketplace.Contexts;
using MariElMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using MariElMarketplace.Calculators;
using MariElMarketplace.Models.ViewModels;
using MariElMarketplace.Helpers;
using System.Security.Claims;

namespace MariElMarketplace.Controllers
{

    public class HomeController : Controller
    {
        private readonly CalculatorService _calculatorService;
        private readonly ILogger<HomeController> _logger;
        private readonly Context _database;

        public HomeController(ILogger<HomeController> logger, Context context, CalculatorService calculatorService)
        {
            _database = context;
            _logger = logger;
            _calculatorService = calculatorService;
        }

        public IActionResult СommodityProducerLk()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        public IActionResult CustomerLk()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        public IActionResult AdminLk()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new AdminLkViewModel
            {
                AllProducts = _database.Products.ToList(),
                AllRequests = _database.Requests.ToList()
            };
            return View(model);
        }

        public IActionResult СarrierLk()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myRequests = _database.Requests.ToList();
            var myRequestsIds = myRequests.Select(x => x.Id);
            var otherRequests = _database.Requests.Where(x=> !myRequestsIds.Contains(x.Id)).ToList();
            var model = new CarrierLkViewModel
            {
                MyProducts = myRequests,
                OtherProducts = otherRequests
            };
            return View(model);
        }

        public IActionResult Index()
        {
            var products = _database.Products.ToList();
            var bestPr = _calculatorService.GetBestProductTypes(products);
            var model = new HomeViewModel
            {
                BestProductTypes = bestPr,
                Products = products
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = _calculatorService.GetBestSuggestions(id);
            return View(model);
        }

        public IActionResult MainCategories(ProductTypeEnum category)
        {
            var models = _calculatorService.GetByProductType(category);
            return View(models);
        }

        public IActionResult Categories(string subType)
        {
            var models = _calculatorService.GetProductBySubType(subType);
            return View(models);
        }

        public IActionResult Buy(int id, string toRegion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _calculatorService.GetProductById(id);
            _database.Requests.Add(new Requests
            {
                UserId = userId,
                Product = product,
                ToPlaceName = toRegion
            });
            _database.SaveChanges();
            return Content("Success!");
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
