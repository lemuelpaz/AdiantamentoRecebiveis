using AdiantamentoRecebiveis.API.Extensions;
using AdiantamentoRecebiveis.API.Responses;
using AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;
using AdiantamentoRecebiveis.Application.Commands.Corporate.Cadastro;
using MediatR;

namespace AdiantamentoRecebiveis.API.Controllers;

public static class CorporateController
{
    private const string Grupo = "Empresa";
    public static void RegistrarEmpresaController(this WebApplication app)
    {
        var carrinhoGrupo = app
          .CriaGrupo(Grupo)
          .WithTags(Grupo);


        carrinhoGrupo.MapPost("/",
            async (CorporateCadastroCommand request, IMediator mediator) =>
            GlobalResponse.Create201Response(await mediator.Send(request)))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .Accepts<CarrinhoCadastroCommand>("application/json");
    }

}
