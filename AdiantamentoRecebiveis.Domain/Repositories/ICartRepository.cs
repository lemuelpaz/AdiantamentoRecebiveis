using AdiantamentoRecebiveis.Application.Dto;
using AdiantamentoRecebiveis.Domain.Dto;
using AdiantamentoRecebiveis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdiantamentoRecebiveis.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateAsync(Cart createDTO);
        Task<CartDto> GetAsync(int id);
    }
}
