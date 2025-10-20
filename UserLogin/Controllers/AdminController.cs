using Microsoft.AspNetCore.Mvc;
using UserLogin.Services;

namespace UserLogin.Controllers
{
    public class AdminController : Controller
    {
        // fields
        private readonly IUserService _userService;

        // constructor
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: AdminsController
        public ActionResult Index()
        {
            ViewData["Title"] = "Admin";
            ViewBag.Role = "Admin";
            return View();
        }
        // logout
        public IActionResult Logout()
        {
            // Clear authentication session
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("RoleId");

            TempData["SuccessMessage"] = "You have been logged out at" + DateTime.Now.ToString();

            // Redirect to home page after logout
            return RedirectToAction("Login", "Logins");
        }
        // GET: AdminsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
