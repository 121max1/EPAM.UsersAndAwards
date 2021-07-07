using System.Data.SqlClient;
using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.DAL.SqlDAL
{
    public class AwardDAO : IAwardDAO
    {
        private readonly string _connectionString;


        public AwardDAO()
        {
            _connectionString = "Data Source=DESKTOP-MBILUQG;Initial Catalog=UsersAndAwardsDb;Integrated Security=True";
        }
        public void Add(Award entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"INSERT INTO Award (IdAward, Tittle) " +
                        $"VALUES ('{entity.ID}', '{entity.Tittle}')";


                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"DELETE FROM Award WHERE [IdAward] = '{award.ID}'"; 


                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string queryString = $"SELECT * FROM Award";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Award(Guid.Parse(reader["IdAward"].ToString()), reader["Tittle"].ToString());
                    }
                }
            }
        }

        public Award GetByID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"SELECT * FROM Award WHERE IdAward = '{id}'";
                var command = new SqlCommand(queryString, connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Award(Guid.Parse(reader["IdAward"].ToString()), reader["Tittle"].ToString());
                    }
                }
            }
            throw new Exception($"Award with Id={id} doesn't exist");
        }

        public void Update(Award entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"UPDATE Award SET Tittle = '{entity.Tittle}'" +
                     $"WHERE IdAward = '{entity.ID}'";

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
