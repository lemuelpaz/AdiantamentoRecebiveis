
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Persistence;

namespace AdiantamentoRecebiveis.Infrastructure.Repositories;
public class CartNfRepository(DataContext _context) : ICartNfRepository
{
    public async Task<CartNf> CreateAsync(CartNf createDTO)
    {
        _context.Add(createDTO);
        await _context.SaveChangesAsync();
        return createDTO;
    }
}
