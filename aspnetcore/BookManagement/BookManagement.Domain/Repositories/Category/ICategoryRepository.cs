using BookManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories.Category
{
    public interface ICategoryRepository : IRepository<Entities.Category>
    {
        Task<List<CategoryDropdownDto>> GetDropdownCategoriesAsync();
    }
}
