using Microsoft.AspNetCore.Mvc;

namespace UserLogin.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: ReceptionistsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReceptionistsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReceptionistsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceptionistsController/Create
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

        // GET: ReceptionistsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceptionistsController/Edit/5
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

        // GET: ReceptionistsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReceptionistsController/Delete/5
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
