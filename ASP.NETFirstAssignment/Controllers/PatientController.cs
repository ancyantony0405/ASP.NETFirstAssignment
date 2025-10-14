using Microsoft.AspNetCore.Mvc;
using PatientRegistration.Models;
using PatientRegistration.Services;

namespace PatientRegistration.Controllers
{
    public class PatientController : Controller
    {
        // Field
        private readonly IPatientService _patientService;

        // DI Constructor
        public PatientController(IPatientService employeeService)
        {
            _patientService = employeeService;
        }

        // GET: Patient/List
        [HttpGet]
        public ActionResult List()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        // GET: Patient/Create
        [HttpGet]
        public IActionResult Create()
        {
            var memberships = _patientService.GetAllMemberships();
            ViewBag.Memberships = memberships;

            ViewBag.MembershipData = memberships.ToDictionary(m => m.MembershipId, m => new { m.MemberDescription, m.InsuredAmount });

            return View();
        }


        // POST: Patient/Create
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.AddPatient(patient);
                    return RedirectToAction("List");
                }
                ViewBag.Memberships = _patientService.GetAllMemberships();
                return View(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.Memberships = _patientService.GetAllMemberships();
                return View(patient);
            }
        }

        // GET: Patient/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewBag.Memberships = _patientService.GetAllMemberships();

            return View(patient);
        }


        // 🟢 POST: Patient/Edit
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.EditPatient(patient);
                    return RedirectToAction("List"); 
                }
                return View(patient);
            }
            catch
            {
                return View(patient);
            }
        }
    }
}
