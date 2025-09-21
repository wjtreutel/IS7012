using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;

namespace RecruitCatTreutewm.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public EditModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
            IndustryList = _context.Industry.OrderBy(x => x.Name).ToList();
            JobTitleList = _context.JobTitle.OrderBy(x => x.Name).ToList();
            CompanyList = _context.Company.OrderBy(x => x.Name).ToList();
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;
        public List<Industry> IndustryList { get; set; }
        public List<JobTitle> JobTitleList { get; set; }
        public List<Company> CompanyList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate =  await _context.Candidate.FirstOrDefaultAsync(m => m.ID == id);
            if (candidate == null)
            {
                return NotFound();
            }
            Candidate = candidate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.ID == id);
        }
    }
}
