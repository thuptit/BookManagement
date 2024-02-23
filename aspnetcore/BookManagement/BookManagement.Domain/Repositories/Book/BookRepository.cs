using BookManagement.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories.Book
{
    public class BookRepository : RepositoryBase<Entities.Book>, IBookRepository
    {
        public BookRepository(BookManagementDbContext context) : base(context)
        {
        }

        public async Task<PagedBase<GetBookAllPagingDto>> GetAllPagingAsync(string searchText, int pageIndex, int pageSize)
        {
            var query = GetAll()
                .Where(_ => string.IsNullOrEmpty(searchText) || _.Name.Contains(searchText) || _.Description.Contains(searchText))
                .Select(_ => new GetBookAllPagingDto
                {
                    CategoryName = _.Category.Name,
                    Name = _.Name,
                    Description = _.Description,
                    Id = _.Id
                });
            return new PagedBase<GetBookAllPagingDto>(
                await query.Skip(pageIndex).Take(pageSize).ToListAsync(),
                await query.CountAsync()
            );
        }

        public async Task<GetBookDetailDto> GetBookDetailAsync(int id)
        {
            return await GetAll()
                .Where(x => x.Id == id)
                .Select(_ => new GetBookDetailDto
                {
                    CategoryId = _.CategoryId,
                    Description = _.Description,
                    Id = _.Id,
                    Name = _.Name,
                })
                .FirstAsync();
        }
        
    }
}
