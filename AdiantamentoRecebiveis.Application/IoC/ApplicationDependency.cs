

using AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;
using AdiantamentoRecebiveis.Application.Commands.Corporate.Cadastro;
using AdiantamentoRecebiveis.Application.Commands.NotaFiscal.Cadastro;
using AdiantamentoRecebiveis.Application.Queries.Carrinho.ObterCarrinho;
using AdiantamentoRecebiveis.Application.Queries.Empresa.ObterEmpresa;
using AdiantamentoRecebiveis.Application.Queries.NotaFiscal.ObterNotaFiscal;
using Microsoft.Extensions.DependencyInjection;

namespace AdiantamentoRecebiveis.Application.IoC;

public static class ApplicationDependency
{
    public static void RegistrarApplicationDependency(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CarrinhoCadastroCommandHandler).Assembly));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(NotaFiscalCadastroCommandHandler).Assembly));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CorporateCadastroCommandHandler).Assembly));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ObterCarrinhoQueryHandler).Assembly));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ObterEmpresaQueryHandler).Assembly));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ObterNotaFiscalQueryHandler).Assembly));
    }
}
