using MongoDB.Bson;
using MongoDB.Driver;
using PortMoni.DATA;
using PortMoni.MODEL;
using System.Collections.Generic;

namespace PortMoni.SERVICES
{
    public class DataBaseServices
    {
        public static List<User> LoadAllUserRecords()
        {
            return LoadAllRecords<User>("users");
        }

        public static void InserNewUser(User user)
        {
            InsertRecord<User>("users", user);
        }

        private static List<T> LoadAllRecords<T>(string table)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        private static void InsertRecord<T>(string table, T record)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
