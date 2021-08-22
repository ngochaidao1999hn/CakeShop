using CakeShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Query
{
    public record GetAllProductQuery():IRequest<IEnumerable<Product>>;
    
}
