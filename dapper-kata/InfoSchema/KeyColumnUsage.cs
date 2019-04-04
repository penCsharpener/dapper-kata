using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata.InfoSchema {
#nullable disable
    public class KeyColumnUsage {
        public string ConstraintCatalog { get; set; }
        public string ConstraintSchema { get; set; }
        public string ConstraintName { get; set; }
        public string TableCatalog { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public long OrdinalPosition { get; set; }
        public long? PositionInUniqueConstraint { get; set; }
        public string ReferencedTableSchema { get; set; }
        public string ReferencedTableName { get; set; }
        public string ReferencedColumnName { get; set; }
    }

    public class KeyColumnUsageMap : EntityMap<KeyColumnUsage> {
        public KeyColumnUsageMap() {
            Map(p => p.ConstraintCatalog).ToColumn("CONSTRAINT_CATALOG");
            Map(p => p.ConstraintSchema).ToColumn("CONSTRAINT_SCHEMA");
            Map(p => p.ConstraintName).ToColumn("CONSTRAINT_NAME");
            Map(p => p.TableCatalog).ToColumn("TABLE_CATALOG");
            Map(p => p.TableSchema).ToColumn("TABLE_SCHEMA");
            Map(p => p.TableName).ToColumn("TABLE_NAME");
            Map(p => p.ColumnName).ToColumn("COLUMN_NAME");
            Map(p => p.OrdinalPosition).ToColumn("ORDINAL_POSITION");
            Map(p => p.PositionInUniqueConstraint).ToColumn("POSITION_IN_UNIQUE_CONSTRAINT");
            Map(p => p.ReferencedTableSchema).ToColumn("REFERENCED_TABLE_SCHEMA");
            Map(p => p.ReferencedTableName).ToColumn("REFERENCED_TABLE_NAME");
            Map(p => p.ReferencedColumnName).ToColumn("REFERENCED_COLUMN_NAME");
        }
    }
}
