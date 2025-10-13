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

    }
}

