using Microsoft.AspNetCore.Mvc;
using UserLogin.Services;

namespace UserLogin.Controllers
{
    public class DoctorController : Controller
    {
        

        // GET: AdminsController
        public ActionResult Index()
        {
            ViewData["Title"] = "Doctor";
            ViewBag.Role = "Doctor";
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
        // GET: DoctorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
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

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorController/Edit/5
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

        // GET: DoctorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorController/Delete/5
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
