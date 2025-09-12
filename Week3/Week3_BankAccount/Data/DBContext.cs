using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week3_BankAccount.Models;

namespace Week3_BankAccount.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.BankAccount> BankAccount { get; set; } = default!;
        public DbSet<Models.AccountHolder> AccountHolder { get; set; } = default!;
    }
}
