using MediatR;

namespace AdiantamentoRecebiveis.Application.Commands.NotaFiscal.Cadastro;

public record NotaFiscalCadastroCommand(int numero, 
                                        decimal valor,
                                        DateTime dataVencimento, 
                                        int empresaId) : IRequest<Domain.Entities.NotasFiscais>;
