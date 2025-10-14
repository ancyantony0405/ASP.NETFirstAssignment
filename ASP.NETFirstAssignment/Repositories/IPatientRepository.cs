using PatientRegistration.Models;

namespace PatientRegistration.Repositories
{
    public interface IPatientRepository
    {
        // List all patients
        IEnumerable<Patient> GetAllPatients();

        // List all memberships
        List<Membership> GetAllMemberships();

        // Insert a new patient
        void InsertPatient(Patient patient);

        // Get a patient by ID
        Patient GetPatientById(int patientId);

        // Update an existing patient
        void EditPatient(Patient patient);
    }
}
