using System;
using AdiantamentoRecebiveis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdiantamentoRecebiveis.Infrastructure.Persistence;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<Corporate> corporates { get; set; }
    public DbSet<NotasFiscais> notasFiscais { get; set; }
    public DbSet<Cart> cart { get; set; }
    public DbSet<CartNf> cartNf { get; set; }

    public static async void EnsureDatabaseMigrated(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        try
        {
            // Aplica todas as migrações pendentes
            await dbContext.Database.MigrateAsync();
            Console.WriteLine("Migrações aplicadas com sucesso...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao aplicar migrações: {ex.Message}");
            // Trate o erro conforme necessario (registre, envie notifiacoes, etc.)
        }
    }
}
