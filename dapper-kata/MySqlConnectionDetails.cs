using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata {
    public class MySqlConnectionDetails {

        public MySqlConnectionDetails(string server, string user, string password, ushort port, string database) {
            Server = server;
            User = user;
            Password = password;
            Port = port;
            Database = database;
        }

        private string _server = "localhost";
        public string Server {
            get { return _server; }
            set { _server = value; refreshConnectionString = true; }
        }

        private string _user = "root";
        public string User {
            get { return _user; }
            set { _user = value; refreshConnectionString = true; }
        }

        private string? _password;
        public string? Password {
            get { return _password; }
            set { _password = value; refreshConnectionString = true; }
        }

        private ushort _port = 3306;
        public ushort Port {
            get { return _port; }
            set { _port = value; refreshConnectionString = true; }
        }

        private string? _database;
        public string? Database {
            get { return _database; }
            set { _database = value; refreshConnectionString = true; }
        }

        private bool _requireSSL;
        public bool RequireSSL {
            get { return _requireSSL; }
            set { _requireSSL = value; refreshConnectionString = true; }
        }

        private bool _convertDateTime = true;
        public bool ConvertDateTime {
            get { return _convertDateTime; }
            set { _convertDateTime = value; refreshConnectionString = true; }
        }

        private string? _charSet;
        public string? CharSet {
            get { return _charSet; }
            set { _charSet = value; refreshConnectionString = true; }
        }

        private bool refreshConnectionString;

        private string? _ConnectionString;
        [JsonIgnore]
        public string? ConnectionString {
            get {
                if (string.IsNullOrEmpty(_ConnectionString) || refreshConnectionString) {
                    _ConnectionString = BuildConnectionString();
                    refreshConnectionString = false;
                }
                return _ConnectionString;
            }
        }

        [JsonIgnore]
        public bool ConnectionStringInvalid => string.IsNullOrEmpty(Server) || string.IsNullOrEmpty(User);

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
