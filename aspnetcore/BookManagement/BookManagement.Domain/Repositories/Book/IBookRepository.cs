using BookManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories.Book
{
    public interface IBookRepository : IRepository<Entities.Book>
    {
        Task<GetBookDetailDto> GetBookDetailAsync(int id);
        Task<PagedBase<GetBookAllPagingDto>> GetAllPagingAsync(string searchText, int pageIndex, int pageSize);
    }
}
