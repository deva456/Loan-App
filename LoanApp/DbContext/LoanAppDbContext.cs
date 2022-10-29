using LoanApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.dbContext
{
    public class LoanAppDbContext:IdentityDbContext
    {
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext>options):base(options)
        {
                
        }
        public DbSet<loans> Loans { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<userProfile> userProfiles { get; set; }

        public DbSet<Tenures> Tenures { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<UserAudit> userAudits { get; set; }
    }
}
