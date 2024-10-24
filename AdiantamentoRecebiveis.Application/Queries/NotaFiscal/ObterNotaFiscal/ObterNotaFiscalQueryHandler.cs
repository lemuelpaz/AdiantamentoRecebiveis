
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.NotaFiscal.ObterNotaFiscal;

public class ObterNotaFiscalQueryHandler(INotaFiscalRepository _repository) : IRequestHandler<ObterNotaFiscalQuery, Domain.Entities.NotasFiscais>
{
    public async Task<NotasFiscais> Handle(ObterNotaFiscalQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(request.id);
    }
}
