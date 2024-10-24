 using AdiantamentoRecebiveis.API.Controllers;

namespace AdiantamentoRecebiveis.API.Extensions;

public static class ControllerExtension
{
    public static void RegisterControllers(this WebApplication app)
    {
        app.RegistrarCarrinhoController();
        app.RegistrarEmpresaController();
        app.RegistraNotaFiscalController();
    }
}
