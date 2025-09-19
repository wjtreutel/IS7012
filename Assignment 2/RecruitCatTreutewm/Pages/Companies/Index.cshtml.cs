using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;

namespace RecruitCatTreutewm.Pages.CompanyFolder
{
    public class IndexModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public IndexModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
        }
    }
}
