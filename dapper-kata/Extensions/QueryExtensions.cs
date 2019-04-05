using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata.Extensions {
    public static class QueryExtensions {

        public static SqlResult ToMySQL(this Query query) {
            var compiler = new MySqlCompiler();
            return compiler.Compile(query);
        }
    }
}
