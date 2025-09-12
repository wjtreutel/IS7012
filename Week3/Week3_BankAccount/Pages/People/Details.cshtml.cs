using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Week3_BankAccount.Data;
using Week3_BankAccount.Models;

namespace Week3_BankAccount.Pages.People
{
    public class DetailsModel : PageModel
    {
        private readonly Week3_BankAccount.Data.DBContext _context;

        public DetailsModel(Week3_BankAccount.Data.DBContext context)
        {
            _context = context;
        }

        public AccountHolder AccountHolder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountholder = await _context.AccountHolder.FirstOrDefaultAsync(m => m.IDNumber == id);

            if (accountholder is not null)
            {
                AccountHolder = accountholder;

                return Page();
            }

            return NotFound();
        }
    }
}
