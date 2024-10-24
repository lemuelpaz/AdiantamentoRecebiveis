using AdiantamentoRecebiveis.Domain.Entities.Default;

namespace AdiantamentoRecebiveis.Domain.Entities;
public class CartNf : DefaultDB
{
    public int NotasFiscaisId { get; set; }
    public int CartId { get; set; }

    public NotasFiscais NotasFiscais { get; set; }
    public Cart Cart { get; set; }
}
