using System;
using System.ComponentModel.DataAnnotations;

namespace AdiantamentoRecebiveis.Domain.Entities.Default;

public abstract class DefaultDB
{
    [Key]
    public int? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
