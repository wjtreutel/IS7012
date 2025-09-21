using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatTreutewm.Pages.Candidates
{
    public class IndexModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public IndexModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
            foreach (var entry in _context.Industry.ToList())
            {
                IndustryHash.Add(entry.ID, entry.Name);
            }
            foreach (var entry in _context.JobTitle.ToList())
            {
                JobHash.Add(entry.ID, entry.Name);
            }
            foreach (var entry in _context.Company.ToList())
            {
                CompanyHash.Add(entry.ID, entry.Name);
            }
        }

        public IList<Candidate> Candidate { get;set; } = default!;
        public Hashtable IndustryHash = new Hashtable();
        public Hashtable JobHash = new Hashtable();
        public Hashtable CompanyHash = new Hashtable();

        public async Task OnGetAsync()
        {
            Candidate = await _context.Candidate.ToListAsync();
        }
    }
}
