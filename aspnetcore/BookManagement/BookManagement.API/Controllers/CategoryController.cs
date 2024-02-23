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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-dropdown-list")]
        public async Task<ServiceResponse> GetDropdownList() => await _mediator.Send(new GetDropdownListQuery());
        [HttpPost]
        public async Task<ServiceResponse> Create(CreateCategoryCommand command) => await _mediator.Send(command);
    }
}
