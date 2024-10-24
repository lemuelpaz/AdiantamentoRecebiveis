

using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Commands.NotaFiscal.Cadastro;

public class NotaFiscalCadastroCommandHandler(INotaFiscalRepository _repository) : IRequestHandler<NotaFiscalCadastroCommand, Domain.Entities.NotasFiscais>
{
    public async Task<NotasFiscais> Handle(NotaFiscalCadastroCommand request, CancellationToken cancellationToken)
    {
        var nf = new Domain.Entities.NotasFiscais
        {
            Taxa = 4.65m,
            CorporateId = request.empresaId,
            ValorBruto = request.valor,
            DataVencimento = request.dataVencimento,
            Numero = request.numero
        };
        return await _repository.CreateAsync(nf);
    }
}
