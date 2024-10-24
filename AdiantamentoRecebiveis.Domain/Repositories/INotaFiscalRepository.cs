
using AdiantamentoRecebiveis.Domain.Entities;

namespace AdiantamentoRecebiveis.Domain.Repositories;

public interface INotaFiscalRepository
{
    Task<NotasFiscais> CreateAsync(NotasFiscais createDTO);
    Task<NotasFiscais> GetAsync(int id);
    Task<NotasFiscais> GetNfByCorporate(int id, int empresaId);
}
