using Ambev.DeveloperEvaluation.Integration.TestData;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Ambev.DeveloperEvaluation.Integration.Common;

/// <summary>
/// Application factory for integration tests
/// </summary>
public sealed class ApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    /// <summary>
    /// Spins up a PostgreSQL container for the integration tests
    /// </summary>
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:13")
        .WithName("postgresql-integration-tests")
        .Build();

    public Task InitializeAsync() => _dbContainer.StartAsync();

    Task IAsyncLifetime.DisposeAsync() => _dbContainer.StopAsync();

    /// <summary>
    /// Configure the web host for the integration tests
    /// </summary>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dbContextDescriptior = services
                .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DefaultContext>));

            if (dbContextDescriptior is not null)
                services.Remove(dbContextDescriptior);

            services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(_dbContainer.GetConnectionString()));

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();

            EnsureDatabaseCreation(dbContext);
            SeedDatabase(dbContext);
        });
    }

    /// <summary>
    /// Ensure that the database is created and migrated
    /// </summary>
    /// <param name="dbContext">Database Context</param>
    private static void EnsureDatabaseCreation(DefaultContext dbContext)
    {
        dbContext.Database.Migrate();
        dbContext.Database.EnsureCreated();
    }

    /// <summary>
    /// Seed the database with default data
    /// </summary>
    /// <param name="dbContext">Database Context</param>
    private static void SeedDatabase(DefaultContext dbContext)
    {
        var user = UserTestData.GetDefaultUser();
        dbContext.Users.Add(user);
        dbContext.SaveChanges();

        var sale = SaleTestData.GetDefaultSale();
        dbContext.Sales.Add(sale);
        dbContext.SaveChanges();
    }
}