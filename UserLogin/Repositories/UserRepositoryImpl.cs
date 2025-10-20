using System.Data.SqlClient;
using UserLogin.Models;

namespace UserLogin.Repositories
{
    public class UserRepositoryImpl
    {
        // field
        private readonly string _connectionString;

        // constructor
        public UserRepositoryImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MVCConnectionString");
        }
        #region Authenticate user
        public User AuthenticateUser(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT u.UserId, u.UserName, u.Email, u.Password, u.RoleId, r.RoleName
                      FROM TblUsers u 
                      JOIN TblRoles r ON u.RoleId = r.RoleId
                      WHERE u.UserName = @UserName AND u.Password = @Password";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),          // UserId
                                UserName = reader.GetString(1),       // UserName
                                Email = reader.GetString(2),          // Email
                                Password = reader.GetString(3),       // Password
                                RoleId = reader.GetInt32(4),          // RoleId
                                Role = new Role
                                {
                                    RoleId = reader.GetInt32(4),      // RoleId
                                    RoleName = reader.GetString(5)    // RoleName
                                }
                            };
                        }
                    }
                }
            }
            return null;

        }

        #endregion
    }
}
