
namespace AdiantamentoRecebiveis.Application.Dto;

public class AntecipacaoDto
{
    public int? Id { get; set; }
    public string Empresa { get; set; }
    public string Cnpj { get; set; }
    public decimal Limite { get; set; }
    public List<NotaFiscalDto> NotasFiscais { get; set; }
    public decimal TotalBruto { get; set; }
    public decimal TotalLiquido { get; set; }
}
