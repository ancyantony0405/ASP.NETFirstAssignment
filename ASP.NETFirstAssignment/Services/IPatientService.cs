using PatientRegistration.Models;

namespace PatientRegistration.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        List<Membership> GetAllMemberships();
        void AddPatient(Patient patient);
        Patient GetPatientById(int patientId);
        void EditPatient(Patient patient);
    }
}
