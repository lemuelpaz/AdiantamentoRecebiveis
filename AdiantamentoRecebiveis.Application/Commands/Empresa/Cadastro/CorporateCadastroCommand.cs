using AdiantamentoRecebiveis.Domain.Enum;
using MediatR;

namespace AdiantamentoRecebiveis.Application.Commands.Corporate.Cadastro;
public record CorporateCadastroCommand(string nome,
                                        string cnpj,
                                        decimal faturamentoMensal,
                                        TipoRamo tipoRamo) : IRequest<Domain.Entities.Corporate>;

