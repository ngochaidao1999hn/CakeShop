using CakeShop.Domain.Entities;
using CakeShop.Dtos.ProductDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Query
{
    public class GetProductByIdQuery:IRequest<ProductDetailPageDto>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id) {
            Id = id;
        }
    }
}
