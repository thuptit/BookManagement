using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Commands
{
    public record CreateCategoryCommand(string name, string description) : IRequest<ServiceResponse>;
}
