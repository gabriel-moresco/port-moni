using MongoDB.Driver;
using System;

namespace PortMoni.DATA
{
    public class DataBaseConnection
    {
        private const string _dataBaseString = "portmoni";
        private const string _connectionString = "mongodb://gmoresco:5571243@portmonicluster-shard-00-00-ne7mx.mongodb.net:27017,portmonicluster-shard-00-01-ne7mx.mongodb.net:27017,portmonicluster-shard-00-02-ne7mx.mongodb.net:27017/test?ssl=true&replicaSet=PortMoniCluster-shard-0&authSource=admin&retryWrites=true&w=majority";

        public IMongoDatabase DataBase { get; set; }

        private DataBaseConnection()
        {
            try
            {
                IMongoClient client = new MongoClient(_connectionString);
                DataBase = client.GetDatabase(_dataBaseString);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter conexão com o banco de dados:\n" + ex.Message);
            }
        }

        private static DataBaseConnection _instance;
        public static DataBaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBaseConnection();
                }

                return _instance;
            }
        }
    }
}
