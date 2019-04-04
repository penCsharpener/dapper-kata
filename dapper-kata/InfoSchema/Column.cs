using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperKata.InfoSchema {
#nullable disable
    public class Column {
        public string TableCatalog { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public ulong OrdinalPosition { get; set; }
        public string ColumnDefault { get; set; }
        public string IsNullable { get; set; }
        public string DataType { get; set; }
        public ulong? CharacterMaximumLength { get; set; }
        public ulong? CharacterOctetLength { get; set; }
        public ulong? NumericPrecision { get; set; }
        public ulong? NumericScale { get; set; }
        public ulong? DatetimePrecision { get; set; }
        public string CharacterSetName { get; set; }
        public string CollationName { get; set; }
        public string ColumnType { get; set; }
        public string ColumnKey { get; set; }
        public string Extra { get; set; }
        public string Privileges { get; set; }
        public string ColumnComment { get; set; }
        public string IsGenerated { get; set; }
        public string GenerationExpression { get; set; }
    }

    public class ColumnMap : EntityMap<Column> {

        public ColumnMap() {
            Map(p => p.TableCatalog).ToColumn("TABLE_CATALOG");
            Map(p => p.TableSchema).ToColumn("TABLE_SCHEMA");
            Map(p => p.TableName).ToColumn("TABLE_NAME");
            Map(p => p.ColumnName).ToColumn("COLUMN_NAME");
            Map(p => p.OrdinalPosition).ToColumn("ORDINAL_POSITION");
            Map(p => p.ColumnDefault).ToColumn("COLUMN_DEFAULT");
            Map(p => p.IsNullable).ToColumn("IS_NULLABLE");
            Map(p => p.DataType).ToColumn("DATA_TYPE");
            Map(p => p.CharacterMaximumLength).ToColumn("CHARACTER_MAXIMUM_LENGTH");
            Map(p => p.CharacterOctetLength).ToColumn("CHARACTER_OCTET_LENGTH");
            Map(p => p.NumericPrecision).ToColumn("NUMERIC_PRECISION");
            Map(p => p.NumericScale).ToColumn("NUMERIC_SCALE");
            Map(p => p.DatetimePrecision).ToColumn("DATETIME_PRECISION");
            Map(p => p.CharacterSetName).ToColumn("CHARACTER_SET_NAME");
            Map(p => p.CollationName).ToColumn("COLLATION_NAME");
            Map(p => p.ColumnType).ToColumn("COLUMN_TYPE");
            Map(p => p.ColumnKey).ToColumn("COLUMN_KEY");
            Map(p => p.Extra).ToColumn("EXTRA");
            Map(p => p.Privileges).ToColumn("PRIVILEGES");
            Map(p => p.ColumnComment).ToColumn("COLUMN_COMMENT");
            Map(p => p.IsGenerated).ToColumn("IS_GENERATED");
            Map(p => p.GenerationExpression).ToColumn("GENERATION_EXPRESSION");
        }
    }
}
