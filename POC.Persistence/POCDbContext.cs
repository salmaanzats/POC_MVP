using Microsoft.EntityFrameworkCore;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Persistence
{
    public class POCDbContext : DbContext
    {
        public POCDbContext(DbContextOptions<POCDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(POCDbContext).Assembly);

            // used only for seeding
            //for (int i = 1; i <= 10000; i++)
            //{

            //    modelBuilder.Entity<User>().HasData(new User
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = $"{i}-Umair",
            //        LastName = $"{i}-Salmaan",
            //        Address = $"{i}-Colombo",
            //        School = $"{i}-UCD Dublin",
            //        Gender = Utility.BaseEnums.Gender.Male
            //    });
            //}
        }

    }
}
