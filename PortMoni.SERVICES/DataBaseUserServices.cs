using MongoDB.Driver;
using PortMoni.DATA;
using PortMoni.MODEL;
using System.Collections.Generic;

namespace PortMoni.SERVICES
{
    public class DataBaseUserServices
    {
        public static List<User> GetAllUser()
        {
            return DataBaseCommonServices.LoadAllRecords<User>("users");
        }

        public static User GetUserByUserName(string userName)
        {
            var usersTable = DataBaseConnection.Instance.DataBase.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("UserName", userName);

            return usersTable.Find(filter).FirstOrDefault();
        }

        public static User GetUserByEmail(string email)
        {
            var usersTable = DataBaseConnection.Instance.DataBase.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("Email", email);

            return usersTable.Find(filter).FirstOrDefault();
        }

        public static void InserNewUser(User user)
        {
            DataBaseCommonServices.InsertRecord<User>("users", user);
        }
    }
}
