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
    public class AwardDAO : IAwardDAO
    {
        public const string JsonFilesPath = @"C:\Users\Максим\source\repos\Epam.UserAwards\Files\Awards";
        public void Add(Award entity)
        {
            string json = JsonConvert.SerializeObject(entity);

            File.WriteAllText(GetPathToFile(entity), json);
        }

        public void Delete(Award award)
        {
            if (File.Exists(GetPathToFile(award)))
                File.Delete(GetPathToFile(award));
            else throw new FileNotFoundException($"File with name {award.ID} at path {JsonFilesPath} isn't created");

        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awardsToReturn = new List<Award>();
            foreach (var file in Directory.GetFiles(JsonFilesPath))
            {
                string text = File.ReadAllText(file);
                var award = JsonConvert.DeserializeObject<Award>(text);
                awardsToReturn.Add(award);
            }
            return awardsToReturn;

        }

        public Award GetByID(Guid id)
        {
            var path = JsonFilesPath + @"\" + id + ".json";
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<Award>(File.ReadAllText(path));
            }

            else return null;
        }

        private static string GetPathToFile(Award award)
        {
            return JsonFilesPath + @"\" + award.ID + ".json";
        }

        public void Update(Award entity)
        {
            Delete(entity);
            Add(entity);
        }
    }
}
