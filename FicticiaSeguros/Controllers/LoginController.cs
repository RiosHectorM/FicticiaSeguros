using FicticiaSeguros.Models;
using FicticiaSeguros.Services;
using Microsoft.AspNetCore.Mvc;

namespace FicticiaSeguros.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserContext _context;

        public LoginController(IUserService userService, UserContext context)
        {
            _userService = userService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
