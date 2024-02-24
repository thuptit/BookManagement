using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Queries
{
    public record GetBookDetailQuery(int id) : IRequest<ServiceResponse>;
    public record GetBookPagingQuery(string? searchText, int pageSize, int pageIndex) : IRequest<ServiceResponse>;
}
