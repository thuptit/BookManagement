using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Shared.Responses;
using MediatR;

namespace BookManagement.Application.Commands
{
    public record CreateBookCommand(string name, string description, int? categoryId) : IRequest<ServiceResponse>;

    public record UpdateBookCommand(int id, string name, string description, int? categoryId)
        : IRequest<ServiceResponse>;

    public record DeleteBookCommand(int id) : IRequest<ServiceResponse>;
}
