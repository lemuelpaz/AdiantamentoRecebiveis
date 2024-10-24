using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Dto;
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Persistence;

namespace AdiantamentoRecebiveis.Infrastructure.Repositories;
public class CartRepository(DataContext _context) : ICartRepository
{
    public async Task<Cart> CreateAsync(Cart createDTO)
    {
        _context.Add(createDTO);
        await _context.SaveChangesAsync();
        return createDTO;
    }

    public Task<CartDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
