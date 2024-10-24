using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Repositories;

namespace AdiantamentoRecebiveis.API.Ioc
{
    /// <summary>
    /// Static class for setting up dependency injection.
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// Configures the dependency injection container with the necessary services and repositories.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        public static void LoadDependencyInjection(IServiceCollection services)
        {
            #region Repository
            services.AddTransient<ICorporateRepository, CorporateRepository>();
            services.AddTransient<IAntecipacaoRepository, AntecipacaoRepository>();
            services.AddTransient<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartNfRepository, CartNfRepository>();
            #endregion
        }
    }
}
