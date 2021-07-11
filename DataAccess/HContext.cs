using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HApi.DataAccess.Entities;
using System.Linq;

namespace HApi.DataAccess {
    public class HContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<NetworkCard> NetworkCards { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite(@"Data Source=HDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerCPU>().HasKey(o => new { o.ComputerId, o.CPUId });
            modelBuilder.Entity<ComputerGPU>().HasKey(o => new { o.ComputerId, o.GPUId });
            modelBuilder.Entity<ComputerHDD>().HasKey(o => new { o.ComputerId, o.HDDId });
            modelBuilder.Entity<ComputerNetworkCard>().HasKey(o => new { o.ComputerId, o.NetworkCardId });
            modelBuilder.Entity<ComputerRAM>().HasKey(o => new { o.ComputerId, o.RAMId });
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}