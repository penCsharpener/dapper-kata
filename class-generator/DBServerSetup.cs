using Newtonsoft.Json;
using System;
using System.IO;

namespace DapperKata.ClassGenerator {
    internal static class DBServerSetup {
        const string connectionFile = "connectionDetails.json";

        internal static MySqlConnectionDetails GetConnectionDetails() {
            MySqlConnectionDetails? connection = null;
            try {
                // if the file doesn't exist, write it to the applications directory
                if (!File.Exists(connectionFile)) {
                    var contentToWrite = JsonConvert.SerializeObject(new MySqlConnectionDetails("", "", "", 3306, ""), Formatting.Indented);
                    File.WriteAllText(connectionFile, contentToWrite);
                }

                // now that we can safely assume it exists, serialise it and check if it's been filled in
                if (File.Exists(connectionFile)) {
                    var fileContent = File.ReadAllText(connectionFile);
                    connection = JsonConvert.DeserializeObject<MySqlConnectionDetails>(fileContent);
                    if (connection.ConnectionStringInvalid) {
                        Console.WriteLine($"Please fill in the connection details in '{new FileInfo(connectionFile).FullName}'");
                        Environment.Exit(1);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            // function will terminate application above if there is no valid connection object
            return connection!;
        }
    }
}
