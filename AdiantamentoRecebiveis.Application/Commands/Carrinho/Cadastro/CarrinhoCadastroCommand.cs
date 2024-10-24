
using AdiantamentoRecebiveis.Application.Dto;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;

public class CarrinhoCadastroCommand : IRequest<AntecipacaoDto>
{
    public int empresaId { get; set; }
    public List<int> NfsId { get; set; }
}
