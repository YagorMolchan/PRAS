using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRAS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<New> News { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
