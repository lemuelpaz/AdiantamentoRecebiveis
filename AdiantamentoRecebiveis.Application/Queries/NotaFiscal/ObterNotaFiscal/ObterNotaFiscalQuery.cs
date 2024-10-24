
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.NotaFiscal.ObterNotaFiscal;

public record ObterNotaFiscalQuery(int id) : IRequest<Domain.Entities.NotasFiscais>;
