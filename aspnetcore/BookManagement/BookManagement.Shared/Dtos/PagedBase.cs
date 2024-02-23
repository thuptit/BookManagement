using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Shared.Dtos
{
    public class PagedBase<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalItems {  get; }
        public PagedBase(IReadOnlyList<T> items, int totalItems)
        {
            Items = items.ToImmutableList();
            TotalItems = totalItems;
        }
    }
}
