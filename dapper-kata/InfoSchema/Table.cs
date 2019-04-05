using Dapper.FluentMap;
using Dapper.FluentMap.Mapping;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperKata.InfoSchema {
#nullable disable
    public class Table : DbBase {

        public const string __SchemaName = "information_schema";
        public const string __TableName = "TABLES";
        private static bool mapped;

        public Table() { }

        public Table(DataConnection connection) : base(connection) { }

        public string TableCatalog { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string TableType { get; set; }
        public string Engine { get; set; }
        public ulong? Version { get; set; }
        public string RowFormat { get; set; }
        public ulong? TableRows { get; set; }
        public ulong? AvgRowLength { get; set; }
        public ulong? DataLength { get; set; }
        public ulong? MaxDataLength { get; set; }
        public ulong? IndexLength { get; set; }
        public ulong? DataFree { get; set; }
        public ulong? AutoIncrement { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CheckTime { get; set; }
        public string TableCollation { get; set; }
        public ulong? Checksum { get; set; }
        public string CreateOptions { get; set; }
        public string TableComment { get; set; }
        public ulong? MaxIndexLength { get; set; }
        public string Temporary { get; set; }

        public static async Task<IEnumerable<Table>> GetList(DataConnection Db,
                                                string[] databaseNames = null,
                                                string[] tableNames = null) {

            if (!mapped) {
                FluentMapper.Initialize(config => config.AddMap(new TableMap()));
                mapped = true;
            }

            var compiler = new MySqlCompiler();
            var qf = new QueryFactory(Db.Con, compiler);
            return await qf.Query($"{__SchemaName}.{__TableName}")
                .WhereIn("TABLE_SCHEMA", databaseNames)
                .WhereIn("TABLE_NAME", tableNames)
                .GetAsync<Table>();
        }
    }

    public class TableMap : EntityMap<Table> {
        public TableMap() {
            Map(p => p.TableCatalog).ToColumn("TABLE_CATALOG");
            Map(p => p.TableSchema).ToColumn("TABLE_SCHEMA");
            Map(p => p.TableName).ToColumn("TABLE_NAME");
            Map(p => p.TableType).ToColumn("TABLE_TYPE");
            Map(p => p.Engine).ToColumn("ENGINE");
            Map(p => p.Version).ToColumn("VERSION");
            Map(p => p.RowFormat).ToColumn("ROW_FORMAT");
            Map(p => p.TableRows).ToColumn("TABLE_ROWS");
            Map(p => p.AvgRowLength).ToColumn("AVG_ROW_LENGTH");
            Map(p => p.DataLength).ToColumn("DATA_LENGTH");
            Map(p => p.MaxDataLength).ToColumn("MAX_DATA_LENGTH");
            Map(p => p.IndexLength).ToColumn("INDEX_LENGTH");
            Map(p => p.DataFree).ToColumn("DATA_FREE");
            Map(p => p.AutoIncrement).ToColumn("AUTO_INCREMENT");
            Map(p => p.CreateTime).ToColumn("CREATE_TIME");
            Map(p => p.UpdateTime).ToColumn("UPDATE_TIME");
            Map(p => p.CheckTime).ToColumn("CHECK_TIME");
            Map(p => p.TableCollation).ToColumn("TABLE_COLLATION");
            Map(p => p.Checksum).ToColumn("CHECKSUM");
            Map(p => p.CreateOptions).ToColumn("CREATE_OPTIONS");
            Map(p => p.TableComment).ToColumn("TABLE_COMMENT");
            Map(p => p.MaxIndexLength).ToColumn("MAX_INDEX_LENGTH");
            Map(p => p.Temporary).ToColumn("TEMPORARY");
        }
    }
}
