using Dapper.FluentMap;
using DapperKata.InfoSchema;
using Mono.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DapperKata.ClassGenerator {
    static class Program {

        private static bool showHelp = false;
        private static bool verbose = false;
        private static bool fromFile = false;
        private static string mode = "";
        private static string database = "";
        private static string single = "";
        private static List<string> extra;

        static async Task Main(string[] args) {

            var p = new OptionSet() {
                            { "m|mode=", "the {MODE} of the export. {print} on screen or write .cs {file} mode.", m => mode = m },
                            { "d|database=", "all tables in database if t flag is not set", r => database = r },
                            { "s|single=", "give full schema.table path to get that table", s => single = s },
                            { "v", "verbose debug messages", v => verbose = v != null },
                            { "f|fromfile", "prints the .json file if it's not there already. otherwise reads .json file with string[] of schema.table to export", f => fromFile = f != null },
                            { "h|help",  "print help and exit", h => showHelp = h != null },
                        };

            try {
                extra = p.Parse(args);

                if (!ValidArguments()) return;
                ShowHelp();
                VerboseArgumentFeedback();

                var conString = DBServerSetup.GetConnectionDetails();
                var db = new DataConnection(conString);

                // for -f flag print all files in the 'table-list.json' array
                if (fromFile) {
                    const string tableList = "table-list.json";
                    // if the file doesn't exist write it to application directory with example tables
                    if (!File.Exists(tableList)) {
                        var fileContent = JsonConvert.SerializeObject(new List<string>() { "information_schema.TABLES", "information_schema.COLUMNS" }, Formatting.Indented);
                        File.WriteAllText(tableList, fileContent);
                    } else {
                        var fileContent = File.ReadAllText(tableList);
                        List<string> tables = JsonConvert.DeserializeObject<List<string>>(fileContent);
                    }
                }

                // When a database is specified but not a table: print all tables in that database
                if (!string.IsNullOrEmpty(database) && string.IsNullOrEmpty(single)) {
                    var tables = (await Table.GetList(db, new[] { database })).ToList();
                }

                // When a database and table are specified: print that specific table
                if (!string.IsNullOrEmpty(database) && !string.IsNullOrEmpty(single)) {
                    var table = (await Table.GetList(db,
                                 databaseNames: new[] { database },
                                 tableNames: new[] { single })).FirstOrDefault();
                }

            } catch (OptionException ex) {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Try '.\\class-generator.exe --help' for more information.");
                return;
            }
        }

        static void VerboseLine(string feedback) {
            if (verbose) {
                Console.WriteLine(feedback);
            }
        }

        static void ShowHelp() {
            if (showHelp) {
                Console.WriteLine("Class Generator Info");
                Console.WriteLine();
                Console.WriteLine($"-m | --mode=        the {{MODE}} of the export. {{print}} on screen or write .cs {{file}} mode.");
                Console.WriteLine($"-d | --database=    all tables in database if t flag is not set.");
                Console.WriteLine($"-s | --single=      give full schema.table path to get that table");
                Console.WriteLine($"-v                  increase debug message verbosity.");
                Console.WriteLine($"-f | --fromfile     prints the .json file if it's not there already. otherwise reads .json file with string[] of schema.table to export");
                Console.WriteLine($"-h | --help         show this message and exit");
                Console.WriteLine();
            }
        }

        static void VerboseArgumentFeedback() {
            if (verbose) {
                Console.WriteLine($"Settings");
                Console.WriteLine($"mode: '{mode}'");
                Console.WriteLine($"database: '{database}'");
                Console.WriteLine($"single: '{single}'");
                Console.WriteLine($"fromfile: '{fromFile}'");
            }
        }

        static bool ValidArguments() {
            if (InvalidFound(string.IsNullOrEmpty(mode), "Mode was not specified!")) return false;
            if (InvalidFound(!string.Equals(mode, "print", StringComparison.OrdinalIgnoreCase) 
                          && !string.Equals(mode, "file", StringComparison.OrdinalIgnoreCase), "Mode not recognised!")) return false;
            if (InvalidFound(string.IsNullOrEmpty(database) && !string.IsNullOrEmpty(single),
                          "To print a single table you need to also specify it's database with the -d flag.")) return false;
            return true;
        }

        static bool InvalidFound(bool condition, string writeline) {
            if (condition) Console.WriteLine("\nERROR\n" + writeline + "\n");
            return condition;
        }
    }
}
