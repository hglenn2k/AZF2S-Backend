namespace AZF2S_Backend.Model.ThirdParty.MongoDb 
{
    public class MongoDbClient(string connectionString, string dataBase, string collection)
    {
        public string ConnectionString { get; } = connectionString;
        public string DataBase { get; } = dataBase;
        public string Collection { get; } = collection;
    }
}
