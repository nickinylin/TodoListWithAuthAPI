using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Models;
using TodoWebAPI.Models.Entities;

namespace TodoWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<ListModel> Lists { get; set; }
        public DbSet<ElementModel> Elements { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ListModel>()
                .Property(e => e.Name).IsRequired();
                



        }
    }
}
