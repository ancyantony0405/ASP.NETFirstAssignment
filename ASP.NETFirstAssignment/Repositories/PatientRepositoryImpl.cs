using PatientRegistration.Models;
using System.Data;
using System.Data.SqlClient;

namespace PatientRegistration.Repositories
{
    public class PatientRepositoryImpl : IPatientRepository
    {
        // field
        private readonly string connectionString;

        // constructor
        public PatientRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        #region GetAllPatients
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        PatientId = (int)reader["PatientId"],
                        RegistrationNo = reader["RegistrationNo"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        Dob = reader["Dob"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNo = reader["PhoneNo"].ToString(),
                        MemberDescription = reader["MemberDescription"].ToString(),
                        InsuredAmount = reader["InsuredAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["InsuredAmount"])
                    });
                }
                con.Close();
            }
            return patients;
        }
        #endregion
        #region Get all memberships
        public List<Membership> GetAllMemberships()
        {
            var list = new List<Membership>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllMemberships", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Membership
                    {
                        MembershipId = (int)reader["MembershipId"],
                        MemberDescription = reader["MemberDescription"].ToString()
                    });
                }
            }

            return list;
        }
        #endregion
        #region Insert Patient
        public void InsertPatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MembershipId", patient.MembershipId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region Get Patient By Id
        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    patient = new Patient
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        RegistrationNo = reader["RegistrationNo"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        Dob = reader["Dob"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNo = reader["PhoneNo"].ToString(),
                        MembershipId = reader["MembershipId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MembershipId"])
                    };
                }
            }

            return patient;
        }
        #endregion

        #region Update Patient
        public void EditPatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", (object?)patient.Dob ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object?)patient.Gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object?)patient.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNo", (object?)patient.PhoneNo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MembershipId", (object?)patient.MembershipId ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}

