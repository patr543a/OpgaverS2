using SqlRocket.Database.Records;
using SqlRocket.Login.Classes;
using System.Data.SqlClient;

namespace SqlRocket.Database.Classes
{
    public class SqlHandler
    {
        private SqlConnection _connection;

        public SqlHandler(string username, string password, int token, string connectionString)
        {
            var valid = LoginHandler.VerifyAccess(username, password, token);

            if (!valid)
                throw new Exception("Ugyldig Login");

            _connection = new SqlConnection(connectionString);
        }

        public List<Rocket> GetRockets(string username, string password, int token)
        {
            var valid = LoginHandler.VerifyAccess(username, password, token);

            if (!valid)
                throw new Exception("Ugyldig Login");

            var c = GetCommand("SELECT * FROM Rockets");
            var r = c.ExecuteReader();

            var data = new List<Rocket>();

            while (r.Read())
                data.Add(GetRocket(r));

            c.Connection.Close();
            c.Connection.Dispose();

            return data;
        }

        public List<LaunchSite> GetLaunchSites(string username, string password, int token)
        {
            var valid = LoginHandler.VerifyAccess(username, password, token);

            if (!valid)
                throw new Exception("Ugyldig Login");

            var c = GetCommand("SELECT * FROM LaunchSites");
            var r = c.ExecuteReader();

            var data = new List<LaunchSite>();

            while (r.Read())
                data.Add(GetLaunchSite(r));

            c.Connection.Close();
            c.Connection.Dispose();

            return data;
        }

        public List<Launch> GetLaunches(string username, string password, int token)
        {
            var valid = LoginHandler.VerifyAccess(username, password, token);

            if (!valid)
                throw new Exception("Ugyldig Login");

            var c = GetCommand("SELECT * FROM Launches");
            var r = c.ExecuteReader();

            var data = new List<Launch>();

            while (r.Read())
                data.Add(GetLaunch(r));

            c.Connection.Close();
            c.Connection.Dispose();

            return data;
        }

        public Rocket GetRocket(SqlDataReader r)
        {
            var id = r.GetInt32(0);
            var name = r.GetString(1);
            var payload = r.GetDecimal(2);
            var width = r.GetDecimal(3);
            var height = r.GetDecimal(4);

            return new Rocket(id, name, payload, width, height);
        }

        public LaunchSite GetLaunchSite(SqlDataReader r)
        {
            var id = r.GetInt32(0);
            var name = r.GetString(1);
            var address = r.GetString(2);
            var longitude = r.GetDecimal(3);
            var latitude = r.GetDecimal(4);
            var founded = r.GetDateTime(5);

            return new LaunchSite(id, name, address, longitude, latitude, founded);
        }

        public Launch GetLaunch(SqlDataReader r)
        {
            var id = r.GetInt32(0);
            var name = r.GetString(1);
            var siteId = r.GetInt32(2);
            var rocketId = r.GetInt32(3);
            var date = r.GetDateTime(4);

            return new Launch(id, name, siteId, rocketId, date);
        }

        private SqlCommand GetCommand(string query)
        {
            var cmd = new SqlCommand(query, _connection);
            cmd.Connection.Open();

            return cmd;
        }

        ~SqlHandler()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
