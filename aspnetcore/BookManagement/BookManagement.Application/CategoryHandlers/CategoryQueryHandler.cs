using BookManagement.Application.Queries;
using BookManagement.Domain.Repositories.Category;
using BookManagement.Shared.Dtos;
using BookManagement.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.CategoryHandlers
{
    public class CategoryQueryHandler(ICategoryRepository _categoryRepository) 
        : IRequestHandler<GetDropdownListQuery, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(GetDropdownListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new OkResponse(await _categoryRepository.GetDropdownCategoriesAsync());
            }
            catch (Exception ex)
            {
                return new FailResponse(ex.Message);
            }
        }

    }
}
