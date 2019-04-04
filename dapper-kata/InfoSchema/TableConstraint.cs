using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata.InfoSchema {
#nullable disable
    public class TableConstraint {
        public string ConstraintCatalog { get; set; }
        public string ConstraintSchema { get; set; }
        public string ConstraintName { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ConstraintType { get; set; }
    }

    public class TableConstraintMap : EntityMap<TableConstraint> {
        public TableConstraintMap() {
            Map(p => p.ConstraintCatalog).ToColumn("CONSTRAINT_CATALOG");
            Map(p => p.ConstraintSchema).ToColumn("CONSTRAINT_SCHEMA");
            Map(p => p.ConstraintName).ToColumn("CONSTRAINT_NAME");
            Map(p => p.TableSchema).ToColumn("TABLE_SCHEMA");
            Map(p => p.TableName).ToColumn("TABLE_NAME");
            Map(p => p.ConstraintType).ToColumn("CONSTRAINT_TYPE");
        }
    }
}
