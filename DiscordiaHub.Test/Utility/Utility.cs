using System;
using System.Collections.Generic;
using System.Text;
using DiscordiaHub.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordiaHub.Tests.Helpers
{
    public static class Utility
    {
        public static DbContextOptions<HubContext> CreateNewContextOptions(string databaseName)
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<HubContext>();
            builder.UseInMemoryDatabase(databaseName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
