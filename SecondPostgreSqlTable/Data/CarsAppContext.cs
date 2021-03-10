using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondPostgreSqlTable.Models;

namespace SecondPostgreSqlTable.Data
{
    public class CarsAppContext: DbContext
    {
        public CarsAppContext(DbContextOptions<CarsAppContext> options) : base(options) { }

        public  DbSet<SecondPostgreSqlTable.Models.CarsModel> CarsModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarsModel>().ToTable("CarDB");
        }
    }
}
