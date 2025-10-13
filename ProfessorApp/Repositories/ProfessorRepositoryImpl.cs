using ProfessorApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProfessorApp.Repositories
{
    public class ProfessorRepositoryImpl : IProfessorRepository
    {
        // field
        private readonly string connectionString;

        // constructor
        public ProfessorRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }
        
        #region Get all professors
        public IEnumerable<Professor> GetAllProfessor()
        {
            List<Professor> list = new List<Professor>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetProfessorList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Professor prof = new Professor
                    {
                        ProfessorId = (int)reader["ProfessorId"],
                        ManagerId = reader["ManagerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ManagerId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DeptName = reader["DeptName"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString()
                    };
                    list.Add(prof);
                }
            }
            return list;
        }
        #endregion

        #region Get all departments
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllDepartments", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Department dept = new Department
                    {
                        DeptNo = Convert.ToInt32(reader["DeptNo"]),
                        DeptName = reader["DeptName"].ToString()
                    };
                    departments.Add(dept);
                }
            }

            return departments;
        }
        #endregion

        #region Add new professor
        public void AddProfessor(Professor professor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ManagerId", (object)professor.ManagerId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FirstName", professor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", professor.LastName);
                cmd.Parameters.AddWithValue("@DeptNo", professor.DeptNo);
                cmd.Parameters.AddWithValue("@Salary", professor.Salary);
                cmd.Parameters.AddWithValue("@JoiningDate", professor.JoiningDate);
                cmd.Parameters.AddWithValue("@DateOfBirth", professor.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", professor.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

    }
}
