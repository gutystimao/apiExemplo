using apiExemplo.src.Models;
using MongoDB.Driver;

namespace apiExemplo.src.Data
{
    public class AppDbContext
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public AppDbContext()
        {
            try
            {
                MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    mongoClientSettings.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoClient = new MongoClient(mongoClientSettings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch
            {
                throw new Exception("Failed to connect to database.");
            }
        }

        public IMongoCollection<User> Usuarios
        {
            get { return _database.GetCollection<User>("usuarios"); }
        }

        public IMongoCollection<Cliente> Clientes
        {
            get
            {
                return _database.GetCollection<Cliente>("clientes");
            }
        }
        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("products");
            }
        }
    }
}