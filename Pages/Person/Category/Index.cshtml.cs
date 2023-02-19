using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages.Person.Category
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.DatabaseContext _context;

        public IndexModel(RazorPagesTutorial.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Data.Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
