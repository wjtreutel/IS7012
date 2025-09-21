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

namespace RecruitCatTreutewm.Pages.CompanyFolder
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatTreutewm.Data.DBContext _context;

        public DetailsModel(RecruitCatTreutewm.Data.DBContext context)
        {
            _context = context;
        }

        public Company Company { get; set; } = default!;
        public string Industry  { get; set; }
        public string Position       { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FirstOrDefaultAsync(m => m.ID == id);
           
            Industry = _context.Industry.Where(x => x.ID == company.IndustryID).Select(x => x.Name).FirstOrDefault();
            Position = _context.JobTitle.Where(x => x.ID == company.OpenPositionID).Select(x => x.Name).FirstOrDefault();

            if (company is not null)
            {
                Company = company;

                return Page();
            }

            return NotFound();
        }
    }
}
