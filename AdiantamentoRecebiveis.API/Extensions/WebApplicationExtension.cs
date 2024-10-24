namespace AdiantamentoRecebiveis.API.Extensions;

public static class WebApplicationExtension
{
    public static RouteGroupBuilder CriaGrupo(this WebApplication app, string nomeGrupo)
    {
        return app.MapGroup($"api/{nomeGrupo}")
            .WithTags(nomeGrupo);
    }
}
