using MongoDB.Bson;
using MongoDB.Driver;
using PortMoni.DATA;
using System.Collections.Generic;

namespace PortMoni.SERVICES
{
    public class DataBaseCommonServices
    {
        internal static List<T> LoadAllRecords<T>(string table)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        internal static void InsertRecord<T>(string table, T record)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        internal static T GetRecordByFilter<T>(string table, string fieldToFilter, string filterValue)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(fieldToFilter, filterValue);
            return collection.Find(filter).FirstOrDefault();
        }
    }
}
