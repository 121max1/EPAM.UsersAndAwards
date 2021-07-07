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
    public class UserDAO: IUserDAO
    {
        private readonly string _connectionString;
        
        public UserDAO()
        {
            _connectionString = "Data Source=DESKTOP-MBILUQG;Initial Catalog=UsersAndAwardsDb;Integrated Security=True";
        }

        public void Add(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"INSERT INTO [User](IdUser, Name, DateOfBirth, Age)" +
                        $"VALUES ('{entity.ID}', '{entity.Name}', '{entity.DateOfBirth}', {entity.Age})";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"DELETE FROM [User] Where IdUser = '{user.ID}'";


                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString = $"SELECT * FROM [User]";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User(Guid.Parse(reader["IdUser"].ToString()),
                            reader["Name"].ToString(),
                            DateTime.Parse(reader["DateOfBirth"].ToString()),
                            int.Parse(reader["Age"].ToString()));
                    }
                }
            };
        }

        public User GetByID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString = $"SELECT * FROM [User] Where IdUser = '{id}'";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User(Guid.Parse(reader["IdUser"].ToString()),
                            reader["Name"].ToString(),
                            DateTime.Parse(reader["DateOfBirth"].ToString()),
                            int.Parse(reader["Age"].ToString()));
                    }
                }
            };
            throw new Exception($"User with Id={id} doesn't exist");
        }

        public void Update(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"UPDATE [User] SET Name = '{entity.Name}', DateOfBirth = '{entity.DateOfBirth}', Age = '{entity.Age}'" +
                     $"WHERE IdUser='{entity.ID}'";

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
