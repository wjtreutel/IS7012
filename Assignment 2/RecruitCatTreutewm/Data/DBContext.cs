using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitCatTreutewm.Models;

namespace RecruitCatTreutewm.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<RecruitCatTreutewm.Models.Company> Company { get; set; } = default!;
    }
}
