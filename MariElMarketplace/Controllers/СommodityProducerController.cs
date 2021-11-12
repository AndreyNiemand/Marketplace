using Microsoft.Extensions.Logging;
using MariElMarketplace.Contexts;
using MariElMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;

namespace MariElMarketplace.Controllers
{


    [Authorize]
    public class СommodityProducerController : Controller
    {
        private readonly Context _database;

        public СommodityProducerController(Context context)
        {
            _database = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _database.Roles.FirstOrDefault(x => x.UserId == userId);
            if (role != null && role.Role != Role.Customer && role.Role != Role.Сarrier)
            {
                return NotFound();
            }
            return View();
        }

    }
}
