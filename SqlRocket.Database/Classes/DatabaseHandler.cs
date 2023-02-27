using SqlRocket.Database.Records;

namespace SqlRocket.Database.Classes
{
    public class DatabaseHandler
    {
        private static readonly string _connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=RocketsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlHandler? _handler;

        public string? Connect(string username, string password, int token)
        {
            try
            {
                _handler = new SqlHandler(username, password, token, _connectionString);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return null;
        }

        public List<Rocket> GetRockets(string username, string password, int token) 
            => _handler is null ? throw new Exception("Ikke tilsluttet server") : _handler.GetRockets(username, password, token);

        public List<LaunchSite> GetLaunchSites(string username, string password, int token)
            => _handler is null ? throw new Exception("Ikke tilsluttet server") : _handler.GetLaunchSites(username, password, token);

        public List<Launch> GetLaunches(string username, string password, int token)
            => _handler is null ? throw new Exception("Ikke tilsluttet server") : _handler.GetLaunches(username, password, token);
    }
}
