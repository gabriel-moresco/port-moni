using PortMoni.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortMoni.SERVICES
{
    public class DataBaseUserServices
    {
        public static List<User> GetAllUser()
        {
            return DataBaseCommonServices.LoadAllRecords<User>("users");
        }

        public static User GetUserByUserNameAsync(string userName)
        {
            return DataBaseCommonServices.GetRecordByFilterAsync<User>("users", "UserName", userName).Result;
        }

        public static User GetUserByEmailAsync(string email)
        {
            return DataBaseCommonServices.GetRecordByFilterAsync<User>("users", "Email", email).Result;
        }

        public static void InserNewUser(User user)
        {
            DataBaseCommonServices.InsertRecordAsync("users", user);
        }
    }
}
