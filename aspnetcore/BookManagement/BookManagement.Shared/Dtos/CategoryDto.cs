using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Shared.Dtos
{
    public record CategoryDropdownDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    };
}
