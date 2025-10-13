using PatientRegistration.Models;

namespace PatientRegistration.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        List<Membership> GetAllMemberships();
        void AddPatient(Patient patient);
    }
}
