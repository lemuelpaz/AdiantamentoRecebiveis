using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AdiantamentoRecebiveis.Domain.Entities.Default;
using AdiantamentoRecebiveis.Domain.Enum;

namespace AdiantamentoRecebiveis.Domain.Entities;

public class Corporate : DefaultDB
{
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Cnpj { get; set; }
    [Required]
    public decimal FaturamentoMensal { get; set; }
    [Required]
    public TipoRamo TipoRamo { get; set; }

    public decimal Limite { get; set; }

    #region FK
    [JsonIgnore]
    public IEnumerable<NotasFiscais>? NotasFiscais { get; set; }
    #endregion

    #region Calc
    public decimal CalcularLimite()
    {
        if (FaturamentoMensal >= 100001)
        {
            return TipoRamo == TipoRamo.Servicos ? FaturamentoMensal * 0.60m : FaturamentoMensal * 0.65m;
        }
        else if (FaturamentoMensal >= 50001 && FaturamentoMensal <= 100000)
        {
            return TipoRamo == TipoRamo.Servicos ? FaturamentoMensal * 0.55m : FaturamentoMensal * 0.60m;
        }
        else if (FaturamentoMensal >= 10000 && FaturamentoMensal <= 50000)
        {
            return FaturamentoMensal * 0.50m;
        }
        return 0m;
    }
    #endregion
}
