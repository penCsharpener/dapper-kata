using System;
using System.Text;

namespace DapperKata {
    public class DataConnection {

        public MySqlConnectionDetails ConnectionDetails { get; }

        public DataConnection(MySqlConnectionDetails connectionDetails) {
            ConnectionDetails = connectionDetails;
        }


    }
}
