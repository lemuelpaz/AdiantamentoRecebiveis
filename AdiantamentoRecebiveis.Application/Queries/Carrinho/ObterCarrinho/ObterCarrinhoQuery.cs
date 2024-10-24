

using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Dto;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.Carrinho.ObterCarrinho;

public class ObterCarrinhoQuery : IRequest<AntecipacaoDto>
{
    public int empresaId { get; set; }
    public int id { get; set; }
}

