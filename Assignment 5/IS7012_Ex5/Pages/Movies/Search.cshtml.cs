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
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Movie = await _context.Movie.Where(w => w.Name.StartsWith(query)).OrderBy(o => o.Name).ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Movie = new List<Movie>();
            }
        }
    }
}
