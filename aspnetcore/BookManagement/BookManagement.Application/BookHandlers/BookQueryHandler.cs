using BookManagement.Application.Queries;
using BookManagement.Domain.Repositories.Book;
using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.BookHandlers
{
    public class BookQueryHandler(IBookRepository _bookRepository)
        : IRequestHandler<GetBookDetailQuery, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new OkResponse(await _bookRepository.GetBookDetailAsync(request.id));
            }
            catch (Exception ex)
            {
                return new FailResponse(ex.Message);
            }
        }
    }
}
