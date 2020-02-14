using MongoDB.Bson;
using MongoDB.Driver;
using PortMoni.DATA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortMoni.SERVICES
{
    public class DataBaseCommonServices
    {
        internal static List<T> LoadAllRecords<T>(string table)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        internal static async void InsertRecordAsync<T>(string table, T record)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }

        internal static async Task<T> GetRecordByFilterAsync<T>(string table, string fieldToFilter, string filterValue)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(fieldToFilter, filterValue);
            return await collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        internal static void UpdateRecord<T>(string tableName, dynamic id, T newRecord)
        {
            IMongoCollection<T> collection = DataBaseConnection.Instance.DataBase.GetCollection<T>(tableName);
            collection.ReplaceOne(new BsonDocument("_id", id), newRecord, new ReplaceOptions { IsUpsert = true });
        }
    }
}
