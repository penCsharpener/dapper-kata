using System;
using System.Text;

namespace DapperKata {
    public class DataConnection {

        public DataConnection() {

        }

        public DataConnection(string server, string user, string password, ushort port, string database) {
            Server = server;
            User = user;
            Password = password;
            Port = port;
            Database = database;
        }

        public string Server { get; set; } = "localhost";
        public string User { get; set; } = "root";
        public string Password { get; set; }
        public ushort Port { get; set; } = 3306;
        public string Database { get; set; }
        public bool RequireSSL { get; set; }
        public bool ConvertDateTime { get; set; } = true;
        public string CharSet { get; set; }

        private string BuildConnectionString() {
            var sb = new StringBuilder();
            sb.Append("Server=").Append(Server).Append(";")
                .Append("Uid=").Append(User).Append(";")
                .Append("Pwd=").Append(Password).Append(";")
                .Append("Port=").Append(Port).Append(";");
            if (!string.IsNullOrEmpty(Database)) {
                sb.Append("Database=").Append(Database).Append(";");
            }
            if (RequireSSL) {
                sb.Append("SslMode=Required;");
            }
            if (ConvertDateTime) {
                sb.Append("ConvertZeroDateTime=True;");
            }
            if (!string.IsNullOrEmpty(CharSet)) {
                sb.Append("CharSet=").Append(CharSet).Append(";");
            }

            return sb.ToString();
        }
    }
}
