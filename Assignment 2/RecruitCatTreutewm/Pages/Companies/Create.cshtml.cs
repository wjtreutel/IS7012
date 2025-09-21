using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatTreutewm.Data;
using RecruitCatTreutewm.Models;

namespace RecruitCatTreutewm.Pages.CompanyFolder
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public CreateModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
            IndustryList = _context.Industry.ToList();
            JobTitleList = _context.JobTitle.OrderBy(x => x.Name).ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; } = default!;
        public List<Industry> IndustryList { get; set; } = new List<Industry>();
        public List<JobTitle> JobTitleList { get; set; } = new List<JobTitle>();
        

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Company.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
