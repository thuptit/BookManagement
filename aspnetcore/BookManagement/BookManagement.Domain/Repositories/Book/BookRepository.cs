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
    }
}
