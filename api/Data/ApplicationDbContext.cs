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
        public DbSet<TournamentStage> TournamentStage { get; set; } = default!;
        public DbSet<Team> Team { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User
            modelBuilder.HasSequence<int>("users_id_sequence")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();
                
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('\"users_id_sequence\"')");
            });

            // UserProfile
            modelBuilder.HasSequence<int>("user_profile_id_sequence")
                .StartsAt(1)
                .IncrementsBy(1);
    
            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('\"user_profile_id_sequence\"')");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.UserProfile)
                    .HasForeignKey<UserProfile>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Tournament
            modelBuilder.HasSequence<int>("tournament_id_sequence")
                .StartsAt(1)
                .IncrementsBy(1);
            
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('\"tournament_id_sequence\"')");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Tournaments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // TournamentStage
            modelBuilder.HasSequence<int>("tournament_stage_id_sequence")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<TournamentStage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('\"tournament_stage_id_sequence\"')");

                entity.HasOne(e => e.Tournament)
                    .WithMany(e => e.Stages)
                    .HasForeignKey(e => e.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            // Teams
            modelBuilder.HasSequence<int>("team_id_sequence")
                .StartsAt(1)
                .IncrementsBy(1);
            
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('\"team_id_sequence\"')");
                
            
                entity.HasOne(e => e.Tournament)
                    .WithMany(e => e.Teams)
                    .HasForeignKey(e => e.tournamentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // modelBuilder.Entity<User>()
            //     .HasIndex(e => e.Email)
            //     .IsUnique();
            
            // modelBuilder.Entity<UserProfile>()
            //     .HasOne(e => e.User)
            //     .WithOne(e => e.UserProfile)
            //     .HasForeignKey<UserProfile>(e => e.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Tournament>()
            //     .HasOne(e => e.User)
            //     .WithMany(e => e.Tournaments)
            //     .HasForeignKey(e => e.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<TournamentStage>()
            //     .HasOne(e => e.Tournament)
            //     .WithMany(e => e.Stages)
            //     .HasForeignKey(e => e.TournamentId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Team>()
            //     .HasOne(e => e.Tournament)
            //     .WithMany(e => e.Teams)
            //     .HasForeignKey(e => e.tournamentId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
