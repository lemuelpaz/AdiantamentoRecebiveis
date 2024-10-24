using AdiantamentoRecebiveis.API.Extensions;
using AdiantamentoRecebiveis.API.Responses;
using AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;
using AdiantamentoRecebiveis.Application.Commands.Corporate.Cadastro;
using AdiantamentoRecebiveis.Application.Commands.NotaFiscal.Cadastro;
using MediatR;
using System.Text.RegularExpressions;

namespace AdiantamentoRecebiveis.API.Controllers;

public static class NotaFiscalController
{
    private const string Grupo = "NotaFiscal";
    public static void RegistraNotaFiscalController(this WebApplication app)
    {
        var carrinhoGrupo = app
         .CriaGrupo(Grupo)
         .WithTags(Grupo);


        carrinhoGrupo.MapPost("/",
            async (NotaFiscalCadastroCommand request, IMediator mediator) =>
            GlobalResponse.Create201Response(await mediator.Send(request)))
            .Produces(StatusCodes.Status201Created , typeof(Domain.Entities.NotasFiscais))
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .Accepts<CarrinhoCadastroCommand>("application/json");
    }
}
