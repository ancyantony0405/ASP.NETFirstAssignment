using PatientRegistration.Models;

namespace PatientRegistration.Repositories
{
    public interface IPatientRepository
    {
        // List all patients
        IEnumerable<Patient> GetAllPatients();
        List<Membership> GetAllMemberships();
        void InsertPatient(Patient patient);

    }
}
