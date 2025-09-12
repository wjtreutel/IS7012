using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Week3_BankAccount.Data;
using Week3_BankAccount.Models;

namespace Week3_BankAccount.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly Week3_BankAccount.Data.DBContext _context;

        public DetailsModel(Week3_BankAccount.Data.DBContext context)
        {
            _context = context;
        }

        public BankAccount BankAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankaccount = await _context.BankAccount.FirstOrDefaultAsync(m => m.Number == id);

            if (bankaccount is not null)
            {
                BankAccount = bankaccount;

                return Page();
            }

            return NotFound();
        }
    }
}
