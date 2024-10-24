using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdiantamentoRecebiveis.Infrastructure.Repositories;

public class CorporateRepository(DataContext _context) : ICorporateRepository
{
    public async Task<Corporate> Create(Corporate corporate)
    {
        _context.Add(corporate);
        await _context.SaveChangesAsync();
        return corporate;
    }

    public async Task<Corporate> GetAsync(int id)
    {
        var result = await _context.corporates.FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (result == null)
            throw new Exception("Empresa não encontrada!");
        return result;
    }
}
