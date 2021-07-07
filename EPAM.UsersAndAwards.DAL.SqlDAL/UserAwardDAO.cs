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
    public class UserAwardDAO :IUserAwardDAO
    {
        private readonly string _connectionString;
        public UserAwardDAO()
        {
            _connectionString = "Data Source=DESKTOP-MBILUQG;Initial Catalog=UsersAndAwardsDb;Integrated Security=True";
        }

        public void Add(Guid userID, Guid awardID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"INSERT INTO UserAward (IdUser, IdAward ) " +
                        $"VALUES ('{userID}', '{awardID}')";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteByAward(Guid awardID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"DELETE FROM UserAward WHERE IdAward = '{awardID}'";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteByUser(Guid userID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"DELETE FROM UserAward WHERE IdUser = '{userID}'";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<UserAward> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString = $"SELECT * FROM UserAward";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new UserAward(Guid.Parse(reader["IdUser"].ToString()),
                            Guid.Parse(reader["IdAward"].ToString()));
                    }
                }
            };
        }
    }
}
