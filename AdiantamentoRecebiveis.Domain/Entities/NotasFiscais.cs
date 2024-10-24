using System;
using System.Text.Json.Serialization;
using AdiantamentoRecebiveis.Domain.Entities.Default;

namespace AdiantamentoRecebiveis.Domain.Entities;

public class NotasFiscais : DefaultDB
{
    public int? Numero { get; set; }
    public decimal ValorBruto { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal Taxa { get; set; }
    public int? CorporateId { get; set; }


    #region FK
    [JsonIgnore]
    public Corporate? Corporate { get; set; }
    #endregion
}
