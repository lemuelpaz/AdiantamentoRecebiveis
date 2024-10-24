using AdiantamentoRecebiveis.Domain.Entities;

namespace AdiantamentoRecebiveis.Domain.Repositories;

public interface ICartNfRepository
{
    Task<CartNf> CreateAsync(CartNf createDTO);
}
