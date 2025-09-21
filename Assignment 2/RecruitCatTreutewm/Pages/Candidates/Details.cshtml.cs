using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RecruitCatTreutewm.Pages.Candidates
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public DetailsModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
        }

        public Candidate Candidate { get; set; } = default!;
        public string Industry { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FirstOrDefaultAsync(m => m.ID == id);

            if (candidate is not null)
            {
                Candidate = candidate;
                Company = _context.Company.Where(x => x.ID == candidate.CompanyID).Select(x => x.Name).FirstOrDefault();
                Industry = _context.Industry.Where(x => x.ID == candidate.IndustryID).Select(x => x.Name).FirstOrDefault();
                Position = _context.JobTitle.Where(x => x.ID == candidate.JobTitleID).Select(x => x.Name).FirstOrDefault();

                return Page();
            }

            return NotFound();
        }
    }
}
