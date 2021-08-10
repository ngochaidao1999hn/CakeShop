using CakeShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Query
{ 
    public class GetUserByIdQuery:IRequest<User>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid id) {
            Id = id;
        }
    }
}
