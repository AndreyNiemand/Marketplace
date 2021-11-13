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
            var test = EnumHelper.GetAllValuesWithDescription<ProductTypeEnum>();
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
