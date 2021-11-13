using MariElMarketplace.Contexts;
using MariElMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using MariElMarketplace.Calculators;

namespace MariElMarketplace.Controllers
{


    [Authorize]
    public class СommodityProducerController : Controller
    {
        private readonly Context _database;
        private readonly CalculatorService _calculatorService;

        public СommodityProducerController(Context context, CalculatorService calculatorService)
        {
            _database = context;
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _database.Roles.FirstOrDefault(x => x.UserId == userId);
            if (role != null && role.Role != Role.Customer && role.Role != Role.Сarrier)
            {
                return NotFound();
            }

            var products = _calculatorService.GetProductByFermerId(userId);

            return View(products);
        }

        public IActionResult CreateProduct()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _database.Roles.FirstOrDefault(x => x.UserId == userId);
            if (role != null && role.Role != Role.Customer && role.Role != Role.Сarrier)
            {
                return NotFound();
            }


            return View();
        }

        public IActionResult AddProduct(Product product)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _database.Roles.FirstOrDefault(x => x.UserId == userId);
            if (role != null && role.Role != Role.Customer && role.Role != Role.Сarrier)
            {
                return NotFound();
            }

            product.FermerId = userId;
            _database.Products.Add(product);
            _database.SaveChanges();

            return View();
        }

    }
}
