using tourney.api.Models;
using Microsoft.EntityFrameworkCore;

namespace tourney.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserProfile> UserProfile { get; set; } = default!;
        public DbSet<Tournament> Tournament { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();
            
            modelBuilder.Entity<UserProfile>()
                .HasOne(e => e.User)
                .WithOne(e => e.UserProfile)
                .HasForeignKey<UserProfile>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tournament>()
                .HasOne(e => e.User)
                .WithMany(e => e.Tournaments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
