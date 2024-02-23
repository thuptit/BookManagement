using BookManagement.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories.Category
{
    public class CategoryRepository : RepositoryBase<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(BookManagementDbContext context) : base(context)
        {
        }

        public async Task<List<CategoryDropdownDto>> GetDropdownCategoriesAsync()
        {
            return await GetAll().Select(x => new CategoryDropdownDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}
