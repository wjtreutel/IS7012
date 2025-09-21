using System;
using System.Collections;
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
        public Hashtable IndustryHash = new Hashtable();
        public Hashtable JobHash = new Hashtable();

        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
            foreach (var entry in _context.Industry.ToList())
            {
                IndustryHash.Add(entry.ID, entry.Name);
            }
            foreach (var entry in _context.JobTitle.ToList())
            {
                JobHash.Add(entry.ID, entry.Name);
            }
        }
    }
}
