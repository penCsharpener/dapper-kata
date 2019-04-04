using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata.InfoSchema {
#nullable disable
    public class Schema {
        public string CatalogName { get; set; }
        public string SchemaName { get; set; }
        public string DefaultCharacterSetName { get; set; }
        public string DefaultCollationName { get; set; }
        public string SqlPath { get; set; }
    }

    public class SchemaMap : EntityMap<Schema> {
        public SchemaMap() {
            Map(p => p.CatalogName).ToColumn("CATALOG_NAME");
            Map(p => p.SchemaName).ToColumn("SCHEMA_NAME");
            Map(p => p.DefaultCharacterSetName).ToColumn("DEFAULT_CHARACTER_SET_NAME");
            Map(p => p.DefaultCollationName).ToColumn("DEFAULT_COLLATION_NAME");
            Map(p => p.SqlPath).ToColumn("SQL_PATH");
        }
    }
}
