
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Commands.Corporate.Cadastro;
public class CorporateCadastroCommandHandler(ICorporateRepository _repository) : IRequestHandler<CorporateCadastroCommand, Domain.Entities.Corporate>
{
    public async Task<Domain.Entities.Corporate> Handle(CorporateCadastroCommand request, CancellationToken cancellationToken)
    {
        var empresa = new Domain.Entities.Corporate
        {
            Nome = request.nome,
            Cnpj = request.cnpj,
            TipoRamo = request.tipoRamo,
            FaturamentoMensal = request.faturamentoMensal,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        empresa.Limite = empresa.CalcularLimite();
        return await _repository.Create(empresa);
    }

}
