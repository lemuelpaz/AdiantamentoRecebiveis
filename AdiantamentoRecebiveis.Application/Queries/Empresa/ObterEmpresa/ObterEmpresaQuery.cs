
using MediatR;

namespace AdiantamentoRecebiveis.Application.Queries.Empresa.ObterEmpresa;
public record ObterEmpresaQuery(int id) : IRequest<Domain.Entities.Corporate>;