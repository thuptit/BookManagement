using BookManagement.Application.Commands;
using BookManagement.Application.Queries;
using BookManagement.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<ServiceResponse> Get(int id) => await _mediator.Send(new GetBookDetailQuery(id));

        [HttpGet("get-all-paging")]
        public async Task<ServiceResponse> GetAllPaging(string? searchText, int pageIndex, int pageSize)
            => await _mediator.Send(new GetBookPagingQuery(searchText, pageSize, pageIndex));

        [HttpPost]
        public async Task<ServiceResponse> Create(CreateBookCommand command) => await _mediator.Send(command);

        [HttpPut]
        public async Task<ServiceResponse> Update(UpdateBookCommand command) => await _mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<ServiceResponse> Delete(int id) => await _mediator.Send(new DeleteBookCommand(id));
    }
}
