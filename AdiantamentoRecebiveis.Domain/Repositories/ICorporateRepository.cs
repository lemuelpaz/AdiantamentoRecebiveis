using AdiantamentoRecebiveis.Domain.Entities;
using System;

namespace AdiantamentoRecebiveis.Domain.Repositories;

public interface ICorporateRepository
{
    public Task<Corporate> GetAsync(int id);
    public Task<Corporate> Create(Corporate corporate);
}
