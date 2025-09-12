using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Week3_BankAccount.Data;
using Week3_BankAccount.Models;

namespace Week3_BankAccount.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly DBContext _context;

        public IndexModel(DBContext context)
        {
            _context = context;
        }

        public IList<BankAccount> BankAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BankAccount = await _context.BankAccount.ToListAsync();            
        }
    }
}
