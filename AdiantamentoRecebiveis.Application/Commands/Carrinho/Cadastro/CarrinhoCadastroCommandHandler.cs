using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdiantamentoRecebiveis.Application.Commands.Carrinho.Cadastro;
public class CarrinhoCadastroCommandHandler(ICartRepository _repository,
    ICartNfRepository _cartNfRepository,
    INotaFiscalRepository _notaFiscalRepository,
    IAntecipacaoRepository _antecipacaoRepository) : IRequestHandler<CarrinhoCadastroCommand, AntecipacaoDto>
{
    public async Task<AntecipacaoDto> Handle(CarrinhoCadastroCommand request, CancellationToken cancellationToken)
    {

        Cart cart = new Cart();
        cart.CorporateId = request.empresaId;

        var createCart = await _repository.CreateAsync(cart);
        if (createCart != null)
        {
            foreach (var id in request.NfsId)
            {
                //buscar as nfs
                var getNf = await _notaFiscalRepository.GetNfByCorporate(id, request.empresaId);
                if (getNf != null)
                {
                    await _cartNfRepository.CreateAsync(new CartNf
                    {
                        CartId = createCart.Id!.Value,
                        NotasFiscaisId = getNf.Id!.Value,
                    });
                }
                else
                    continue;
            }
        }
        else
            throw new Exception("Houve um problema ao criar o carrinho!");

        return await _antecipacaoRepository.CalculaAntecipado(request.empresaId, createCart.Id!.Value);
    }
}
