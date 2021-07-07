using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UserAwards.DAL
{
    public class UserDAO : IUserDAO
    {
        public const string JsonFilesPath = @"C:\Users\Максим\source\repos\Epam.UserAwards\Files\Users";

        public void Add(User entity)
        {
            string json = JsonConvert.SerializeObject(entity);

            File.WriteAllText(GetPathToFile(entity), json);
        }

        public void Delete(User entity)
        {
            if (File.Exists(GetPathToFile(entity)))
                File.Delete(GetPathToFile(entity));
            else throw new FileNotFoundException($"File with name {entity.ID} at path {JsonFilesPath} isn't created");
        }

        public IEnumerable<User> GetAll()
        {
            List<User> usersToReturn = new List<User>();
            foreach (var file in Directory.GetFiles(JsonFilesPath))
            {
                string text = File.ReadAllText(file);
                var user = JsonConvert.DeserializeObject<User>(text);
                usersToReturn.Add(user);
            }
            return usersToReturn;
        }

        public User GetByID(Guid id)
        {
            var path = JsonFilesPath + @"\" + id + ".json";
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<User>(File.ReadAllText(path));
            }

            else return null;
        }

        private static string GetPathToFile(User user)
        {
            return JsonFilesPath + @"\" + user.ID + ".json";
        }

        public void Update(User entity)
        {
            Delete(entity);
            Add(entity);
        }
    }
}
