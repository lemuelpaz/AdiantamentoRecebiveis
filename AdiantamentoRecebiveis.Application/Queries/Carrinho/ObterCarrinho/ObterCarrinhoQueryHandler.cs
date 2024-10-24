
using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Dto;
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.Carrinho.ObterCarrinho;

public class ObterCarrinhoQueryHandler(IAntecipacaoRepository _antecipacaoRepository) : IRequestHandler<ObterCarrinhoQuery, AntecipacaoDto>
{
    public async Task<AntecipacaoDto> Handle(ObterCarrinhoQuery request, CancellationToken cancellationToken)
    {
        return await _antecipacaoRepository.CalculaAntecipado(request.empresaId, request.id);
    }
}
