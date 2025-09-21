using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;

namespace RecruitCatTreutewm.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public CreateModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
            IndustryList = _context.Industry.OrderBy(x => x.Name).ToList();
            JobTitleList = _context.JobTitle.OrderBy(x => x.Name).ToList();
            CompanyList = _context.Company.OrderBy(x => x.Name).ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;
        public List<Industry> IndustryList { get; set; }
        public List<JobTitle> JobTitleList { get; set; }
        public List<Company> CompanyList { get; set; }  

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
