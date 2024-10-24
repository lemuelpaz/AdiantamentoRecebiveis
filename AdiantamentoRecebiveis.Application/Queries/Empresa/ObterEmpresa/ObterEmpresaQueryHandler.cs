using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.Empresa.ObterEmpresa;
public class ObterEmpresaQueryHandler(ICorporateRepository _repository) : IRequestHandler<ObterEmpresaQuery, Domain.Entities.Corporate>
{
    public async Task<Corporate> Handle(ObterEmpresaQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(request.id);
    }
}
