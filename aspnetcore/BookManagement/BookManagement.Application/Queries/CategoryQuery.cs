using BookManagement.Shared.Dtos;
using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Queries
{
    public record GetDropdownListQuery() : IRequest<ServiceResponse>;
}
