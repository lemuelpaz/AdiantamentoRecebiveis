
using AdiantamentoRecebiveis.Domain.Entities.Default;
using System.Text.Json.Serialization;

namespace AdiantamentoRecebiveis.Domain.Entities;

public class Cart : DefaultDB
{
    public int CorporateId { get; set; }
    public Corporate? Corporate { get; set; }
    [JsonIgnore]
    public IEnumerable<CartNf>? CartNf { get; set; }


}
