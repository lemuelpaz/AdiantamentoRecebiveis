
using AdiantamentoRecebiveis.Application.Dto;

namespace AdiantamentoRecebiveis.Domain.Repositories;

public interface IAntecipacaoRepository
{
    Task<AntecipacaoDto> CalculaAntecipado(int empresaId, int cartId);

}
