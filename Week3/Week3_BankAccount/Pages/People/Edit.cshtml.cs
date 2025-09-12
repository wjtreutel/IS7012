using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week3_BankAccount.Data;
using Week3_BankAccount.Models;

namespace Week3_BankAccount.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly Week3_BankAccount.Data.DBContext _context;

        public EditModel(Week3_BankAccount.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountHolder AccountHolder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountholder =  await _context.AccountHolder.FirstOrDefaultAsync(m => m.IDNumber == id);
            if (accountholder == null)
            {
                return NotFound();
            }
            AccountHolder = accountholder;
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

            _context.Attach(AccountHolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountHolderExists(AccountHolder.IDNumber))
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

        private bool AccountHolderExists(string id)
        {
            return _context.AccountHolder.Any(e => e.IDNumber == id);
        }
    }
}
