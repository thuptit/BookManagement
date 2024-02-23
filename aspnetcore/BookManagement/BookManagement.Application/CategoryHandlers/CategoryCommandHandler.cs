using BookManagement.Application.Commands;
using BookManagement.Domain.Repositories.Category;
using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.CategoryHandlers
{
    public class CategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<CreateCategoryCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return new OkResponse(await _categoryRepository.InsertAsync(new Domain.Entities.Category
                {
                    Description = request.description,
                    Name = request.name,
                }));
            }
            catch (Exception ex)
            {
                return new FailResponse(ex.Message);
            }
        }
    }
}
