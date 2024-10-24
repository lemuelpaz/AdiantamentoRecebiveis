using System;
using AdiantamentoRecebiveis.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdiantamentoRecebiveis.Infrastructure.Persistence;

public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private readonly string? ConnectionString = AppSettings.ConnectionString;
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=JOEL\\SQLEXPRESS;Database=testedb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new DataContext(optionsBuilder.Options);
    }
}
