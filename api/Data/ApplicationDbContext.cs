using api.Models;
using Microsoft.EntityFrameworkCore;
using tourney.Models;

namespace tourney.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserProfile> UserProfile { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();
            
            modelBuilder.Entity<User>()
                .HasOne(e => e.UserProfile)
                .WithOne(e => e.User)
                .HasForeignKey<UserProfile>(e => e.Id);
        }
    }
}
