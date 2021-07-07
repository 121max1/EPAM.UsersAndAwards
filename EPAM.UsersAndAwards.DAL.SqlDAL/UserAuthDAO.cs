using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.DAL.SqlDAL
{
    public class UserAuthDAO : IUserAuthDAO
    {
        private readonly string _connectionString;

        public UserAuthDAO()
        {
            _connectionString = "Data Source=DESKTOP-MBILUQG;Initial Catalog=UsersAndAwardsDb;Integrated Security=True";
        }
        public void Add(UserAuth userAuth)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"INSERT INTO UserLogin (Login, Password, Roles) " +
                        $"VALUES ('{userAuth.Login}', '{userAuth.Password}', '{userAuth.Roles}' )";


                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public UserAuth GetByLogin(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"SELECT * FROM UserLogin WHERE Login = '{login}'";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new UserAuth(reader["Login"].ToString(), reader["Password"].ToString(), reader["Roles"].ToString());
                    }
                }
            }
            throw new Exception($"User with login {login} doesn't exist");
        }
    }
}
