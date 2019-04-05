using System;
using System.Collections.Generic;
using System.Text;
#nullable disable

namespace DapperKata {
    public class DbBase {

        public DataConnection DataConnection { get; set; }

        public DbBase() { }

        public DbBase(DataConnection connection) {
            DataConnection = connection;
        }

    }
}
