using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IS7012_Ex5.Data;
using IS7012_Ex5.Models;

namespace IS7012_Ex5.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IS7012_Ex5.Data.ApplicationDbContext _context;

        public IndexModel(IS7012_Ex5.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
