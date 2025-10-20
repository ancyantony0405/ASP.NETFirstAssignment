using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using UserLogin.Models;
using UserLogin.Repositories;

namespace UserLogin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepositoryImpl _userRepository;

        public UserController(IConfiguration configuration)
        {
            _userRepository = new UserRepositoryImpl(configuration);
        }
        // Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.AuthenticateUser(username, password);

            if (user != null)
            {
                // Store basic session details
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("RoleName", user.Role.RoleName);

                // Redirect based on role
                switch (user.Role.RoleName)
                {
                    case "Admin":
                        return RedirectToAction("Index", "Admin");
                    case "Doctor":
                        return RedirectToAction("Index", "Doctor");
                    case "Receptionist":
                        return RedirectToAction("Index", "Receptionist");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }
        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
