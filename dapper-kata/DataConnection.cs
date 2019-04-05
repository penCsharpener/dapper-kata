using Dapper;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace DapperKata {
    public class DataConnection {

        public SqlConnectionDetails ConnectionDetails { get; }
        public DbConnection Con { get; }

        public DataConnection(SqlConnectionDetails connectionDetails) {
            ConnectionDetails = connectionDetails;
            Con = new MySqlConnection(ConnectionDetails.ConnectionString);
        }
    }
}
