using Microsoft.AspNetCore.Mvc;
using PatientRegistration.Models;
using PatientRegistration.Services;

namespace PatientRegistration.Controllers
{
    public class PatientModalController : Controller
    {
        // Field
        private readonly IPatientService _patientService;

        // DI
        public PatientModalController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: PatientModal
        public ActionResult Index()
        {
            // Populatng viewBag for department
            ViewBag.Memberships = _patientService.GetAllMemberships();

            List<Patient> patients = _patientService.GetAllPatients().ToList();
            return View(patients);
        }

        // GET: PatientModalController/Create
        public ActionResult Create()
        {
            // Populating viewbag for department
            ViewBag.Memberships = _patientService.GetAllMemberships();
            return View();
        }

        // POST: PatientModalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.AddPatient(emp);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientModalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientModalController/Edit/5
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

        // GET: PatientModalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientModalController/Delete/5
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
