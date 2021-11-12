using MariElMarketplace.Contexts;
using MariElMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;

namespace MariElMarketplace.Controllers
{

    [Authorize]
    public class СarrierController : Controller
    {

        private readonly Context _database;

        public СarrierController(Context context)
        {
            _database = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _database.Roles.FirstOrDefault(x => x.UserId == userId);
            if (role != null && role.Role != Role.Customer && role.Role != Role.СommodityProducer)
            {
                return NotFound();
            }
            return View();
        }

    }
}
