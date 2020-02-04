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
            return DataBaseCommonServices.GetRecordByFilter<User>("users", "UserName", userName);
        }

        public static User GetUserByEmail(string email)
        {
            return DataBaseCommonServices.GetRecordByFilter<User>("users", "Email", email);
        }

        public static void InserNewUser(User user)
        {
            DataBaseCommonServices.InsertRecord("users", user);
        }
    }
}
