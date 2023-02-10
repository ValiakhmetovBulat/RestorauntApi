using Microsoft.EntityFrameworkCore;
using RestorauntApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorauntApi.Models
{
    public class RestorauntDbContext : DbContext
    {
        public RestorauntDbContext(DbContextOptions<RestorauntDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<MenuPosition>().Property(m => m.Id).UseIdentityColumn();
            modelBuilder.Entity<Section>().Property(s => s.Id).UseIdentityColumn();
            modelBuilder.Entity<PositionType>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Admin>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Review>().Property(p => p.Id).UseIdentityColumn();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<MenuPosition> MenuPositions { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
