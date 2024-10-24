using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Entities;
using AdiantamentoRecebiveis.Domain.Repositories;
using AdiantamentoRecebiveis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdiantamentoRecebiveis.Infrastructure.Repositories;
public class AntecipacaoRepository(DataContext _context) : IAntecipacaoRepository
{
    public async Task<AntecipacaoDto> CalculaAntecipado(int empresaId, int cartId)
    {
        var query = (from a in _context.cart
                     join b in _context.corporates on a.CorporateId equals b.Id
                     join c in _context.cartNf on a.Id equals c.CartId
                     join d in _context.notasFiscais on c.NotasFiscaisId equals d.Id
                     where b.Id == empresaId && a.Id == cartId
                     select new
                     {
                         a.Id,
                         b.Nome,
                         b.Cnpj,
                         b.Limite,
                         d
                     });

        var result = query.AsEnumerable().GroupBy(x => new { x.Id, x.Nome, x.Cnpj, x.Limite })
            .Select(g =>
            {
                var notasFiscais = g.Select(n =>
                {
                    var taxaPercentCalc = 1 + (n.d.Taxa / 100);
                    var prazo = (n.d.DataVencimento - DateTime.Now).Days;
                    var desagio = n.d.ValorBruto - (n.d.ValorBruto / Math.Round((decimal)Math.Pow(Convert.ToDouble(taxaPercentCalc), (prazo / 30.0)), 2));
                    return new NotaFiscalDto
                    {
                        Numero = n.d.Numero!.Value,
                        ValorBruto = n.d.ValorBruto,
                        ValorLiquido = Math.Round(n.d.ValorBruto - desagio, 2),
                    };
                }).ToList();

                var totalLiquido = notasFiscais.Sum(nf => nf.ValorLiquido);

                return new AntecipacaoDto()
                {
                    Id = g.Key.Id,
                    Empresa = g.Key.Nome,
                    Cnpj = g.Key.Cnpj,
                    Limite = g.Key.Limite,
                    NotasFiscais = notasFiscais,
                    TotalBruto = g.Sum(x => x.d.ValorBruto),
                    TotalLiquido = totalLiquido,
                };
            }).FirstOrDefault();

        return result!;
    }

}
