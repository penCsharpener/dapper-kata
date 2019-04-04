using System;
using System.IO;

namespace DapperKata.ClassGenerator {
    static class Program {

        static void Main(string[] args) {

            var conString = DBServerSetup.GetConnectionDetails();
            
            Console.WriteLine(conString.ConnectionString);
        }

        
    }
}
