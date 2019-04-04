using Mono.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DapperKata.ClassGenerator {
    static class Program {

        private static bool showHelp = false;
        private static bool verbose = false;
        private static bool toFile = false;
        private static string mode = "";
        private static string database = "";
        private static string single = "";
        private static List<string> extra;

        static void Main(string[] args) {

            var p = new OptionSet() {
                            { "m|mode=", "the {MODE} of the export. {print} on screen or write .cs {file} mode.", m => mode = m },
                            { "d|database=", "all tables in database if t flag is not set", r => database = r },
                            { "s|single=", "give full schema.table path to get that table", s => single = s },
                            { "v", "increase debug message verbosity", v => verbose = v != null },
                            { "f|fromfile", "prints the .json file if it's not there already. otherwise reads .json file with string[] of schema.table to export", f => toFile = f != null },
                            { "h|help",  "show this message and exit", h => showHelp = h != null },
                        };

            try {
                extra = p.Parse(args);

                if (!ValidArguments()) return;
                ShowHelp();
                VerboseArgumentFeedback();

                if (toFile) {
                    const string tableList = "table-list.json";
                    if (!File.Exists(tableList)) {
                        var fileContent = JsonConvert.SerializeObject(new List<string>() { "database.table1", "database2.table1" }, Formatting.Indented);
                        File.WriteAllText(tableList, fileContent);
                    } else {
                        var fileContent = File.ReadAllText(tableList);
                        List<string> tables = JsonConvert.DeserializeObject<List<string>>(fileContent);
                    }
                }

            } catch (OptionException ex) {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Try '.\\class-generator.exe --help' for more information.");
                return;
            }

            var conString = DBServerSetup.GetConnectionDetails();
            
            Console.WriteLine(conString.ConnectionString);
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
                Console.WriteLine($"fromfile: '{toFile}'");
            }
        }

        static bool ValidArguments() {
            if (InvalidFound(string.IsNullOrEmpty(mode), "Mode was not specified!")) return false;
            return true;
        }

        static bool InvalidFound(bool condition, string writeline) {
            if (condition) Console.WriteLine("\nERROR\n" + writeline + "\n");
            return condition;
        }
    }
}
