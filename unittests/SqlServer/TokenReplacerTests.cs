﻿using FluentAssertions;
using grate.Configuration;
using grate.Infrastructure;
using grate.Migration;

namespace Basic_tests.Infrastructure;

public class TokenReplacerTests(IDatabase database)
{
    [Fact]
    public void EnsureDbMakesItToTokens()
    {
        var config = new GrateConfiguration()
        {
            ConnectionString = "Server=(LocalDb)\\mssqllocaldb;Database=TestDb;",
            Folders = FoldersConfiguration.Default(null)
        };


        database.InitializeConnections(config);

        var provider = new TokenProvider(config, database);
        var tokens = provider.GetTokens();

        tokens["DatabaseName"].Should().Be("TestDb");
        tokens["ServerName"].Should().Be("(LocalDb)\\mssqllocaldb");
    }
}
