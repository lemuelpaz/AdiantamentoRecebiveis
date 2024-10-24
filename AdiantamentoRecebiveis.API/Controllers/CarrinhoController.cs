using AdiantamentoRecebiveis.API.Extensions;
using AdiantamentoRecebiveis.API.Responses;
using AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;
using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Application.Queries.Carrinho.ObterCarrinho;
using AdiantamentoRecebiveis.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AdiantamentoRecebiveis.API.Controllers;
public static class CarrinhoController
{
    private const string Grupo = "Carrinho";

    public static void RegistrarCarrinhoController(this WebApplication app)
    {
        var carrinhoGrupo = app
            .CriaGrupo(Grupo)
            .WithTags(Grupo);



        carrinhoGrupo.MapPost("/",
            async (CarrinhoCadastroCommand request, IMediator mediator) =>
            GlobalResponse.Create201Response(await mediator.Send(request)))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .Accepts<CarrinhoCadastroCommand>("application/json");


        
        carrinhoGrupo.MapGet("/",
            async ([AsParameters] ObterCarrinhoQuery request, IMediator mediator) =>
        {
            return GlobalResponse.Create200Response(await mediator.Send(request));
        })
            .Produces(StatusCodes.Status200OK, typeof(AntecipacaoDto))
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .AllowAnonymous();

    }
}
