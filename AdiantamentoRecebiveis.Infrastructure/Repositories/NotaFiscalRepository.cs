

using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdiantamentoRecebiveis.Infrastructure.Repositories;
public class NotaFiscalRepository(DataContext _context) : INotaFiscalRepository
{
    public async Task<NotasFiscais> CreateAsync(NotasFiscais createDTO)
    {
        _context.Add(createDTO);
        await _context.SaveChangesAsync();
        return createDTO;
    }

    public async Task<NotasFiscais> GetAsync(int id)
    {
        var result = await _context.notasFiscais.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (result == null)
            throw new Exception("Nota fiscal não encontrada!");
        return result;
    }

    public async Task<NotasFiscais> GetNfByCorporate(int id, int empresaId)
    {
        var result = await _context.notasFiscais.FirstOrDefaultAsync(x => x.Id == id && x.CorporateId == empresaId);
        if (result == null)
            throw new Exception("Nota fiscal não encontrada!");
        return result;
    }
}
