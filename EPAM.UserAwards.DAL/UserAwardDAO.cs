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
    public class UserAwardDAO : IUserAwardDAO
    {
        private readonly string JsonFilePath = @"C:\Users\Максим\source\repos\Epam.UserAwards\Files\UserAwardTable.json";
        public void Add(Guid userID, Guid awardID)
        {
            string text = File.ReadAllText(JsonFilePath);
            var awardUserList = JsonConvert.DeserializeObject<List<UserAward>>(text);
            if (awardUserList == null)
            {
                awardUserList = new List<UserAward>();
            }
            awardUserList.Add(new UserAward(userID, awardID));
            string json = JsonConvert.SerializeObject(awardUserList);
            File.Delete(JsonFilePath);
            File.WriteAllText(JsonFilePath, json);
        }

        public void DeleteByAward(Guid awardID)
        {
            string text = File.ReadAllText(JsonFilePath);
            var awardUserList = JsonConvert.DeserializeObject<List<UserAward>>(text);
            string json = JsonConvert.SerializeObject(awardUserList.Where(p => p.IdAward != awardID));
            File.Delete(JsonFilePath);
            File.WriteAllText(JsonFilePath, json);
        }

        public void DeleteByUser(Guid userID)
        {
            string text = File.ReadAllText(JsonFilePath);
            var awardUserList = JsonConvert.DeserializeObject<List<UserAward>>(text);
            string json = JsonConvert.SerializeObject(awardUserList.Where(p => p.IdUser != userID));
            File.Delete(JsonFilePath);
            File.WriteAllText(JsonFilePath, json);
        }

        public IEnumerable<UserAward> GetAll()
        {
            string text = File.ReadAllText(JsonFilePath);
            return JsonConvert.DeserializeObject<List<UserAward>>(text);
        }
    }
}
