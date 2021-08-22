using CakeShop.Dtos.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Command
{
    public record RegisterCommand(RegisterInfo registerinfo) :IRequest<string>;
    
}
