using System;
using System.Threading.Tasks;
using grate.Configuration;
using NUnit.Framework;
using TestCommon.Generic;
using TestCommon.TestInfrastructure;

namespace Oracle;

[TestFixture]
[Category("Oracle")]
public class MigrationTables : GenericMigrationTables
{
    protected override IGrateTestContext Context => GrateTestContext.Oracle;

    protected override Task CheckTableCasing(string tableName, string funnyCasing, Action<GrateConfiguration, string> setTableName)
    {
        Assert.Ignore("Oracle has never been case-sensitive for grate. No need to introduce that now.");
        return Task.CompletedTask;
    }

    protected override string CountTableSql(string schemaName, string tableName)
    {
        return $@"
SELECT COUNT(table_name) FROM user_tables
WHERE 
lower(table_name) = '{tableName.ToLowerInvariant()}'";
    }
}