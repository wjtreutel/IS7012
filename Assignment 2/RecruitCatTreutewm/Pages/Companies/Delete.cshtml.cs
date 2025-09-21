using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatTreutewm.Pages.CompanyFolder
{
    public class DeleteModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public DeleteModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;
        public string Industry { get; set; }
        public string Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FirstOrDefaultAsync(m => m.ID == id);

            if (company is not null)
            {
                Company = company;
                Industry = _context.Industry.Where(x => x.ID == company.IndustryID).Select(x => x.Name).FirstOrDefault();
                Position = _context.JobTitle.Where(x => x.ID == company.OpenPositionID).Select(x => x.Name).FirstOrDefault();
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                Company = company;
                _context.Company.Remove(Company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
