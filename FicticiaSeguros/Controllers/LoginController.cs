using FicticiaSeguros.Models;
using FicticiaSeguros.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.UserPass = Utils.HashPassword(user.UserPass);

            User userCreated = await _userService.SaveUser(user);

            if (userCreated.Id > 0 )
            {
                return RedirectToAction("SignIn","Login");
            }
            ViewData["Message"] = "Error creating user";
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(string mail, string pass)
        {
            
            User userFinded = await _userService.GetUser(mail, Utils.HashPassword(pass));
            if (userFinded == null)
            {
                ViewData["Message"] = "User not found";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userFinded.UserName),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
