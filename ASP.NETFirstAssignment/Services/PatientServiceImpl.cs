using PatientRegistration.Models;
using PatientRegistration.Repositories;

namespace PatientRegistration.Services
{
    public class PatientServiceImpl : IPatientService
    {
        // field 
        private readonly IPatientRepository _patientRepository;

        // DI constructor
        public PatientServiceImpl(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
        }

        public List<Membership> GetAllMemberships()
        {
            return _patientRepository.GetAllMemberships();
        }

        public void AddPatient(Patient patient)
        {
             _patientRepository.InsertPatient(patient);
        }

        public Patient GetPatientById(int patientId)
        {
            return _patientRepository.GetPatientById(patientId);
        }

        public void EditPatient(Patient patient)
        {
            _patientRepository.EditPatient(patient);
        }
    }
}
