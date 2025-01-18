using Microsoft.CodeAnalysis.Scripting.Hosting;
using Microsoft.EntityFrameworkCore;
using tourney.api.Models;

namespace tourney.api.Data
{
    public class Seeder
    {
        public static async void TruncateAll(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE user_profiles CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE teams CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE tournament_stages CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE tournaments CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE users CASCADE;");

            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE user_profile_id_sequence RESTART WITH 1");
            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE tournament_id_sequence RESTART WITH 1");
            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE tournament_stage_id_sequence RESTART WITH 1");
            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE team_id_sequence RESTART WITH 1");
            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE users_id_sequence RESTART WITH 1");
        }
        public static void SeedAll(ApplicationDbContext context)
        {
            TruncateAll(context);
            SeedUsers(context);
            SeedTournaments(context);
            SeedTeams(context);
        }
        public static void SeedUsers(ApplicationDbContext context)
        {
            context.User
                .AddRange(
                    new User
                    {
                        Email = "user1@demo.com",
                        FirstName = "One",
                        LastName = "User",
                        Password = "$2a$11$jPAlB6ahitx.hOeM4FGOY.muL9kkpHaY/vvvSz85byMpbKR4vp0ya", // P@ssw0rd
                        Status = UserStatus.ACTIVE,
                    },
                    new User
                    {
                        Email = "user2@demo.com",
                        FirstName = "Two",
                        LastName = "User",
                        Password = "$2a$11$jPAlB6ahitx.hOeM4FGOY.muL9kkpHaY/vvvSz85byMpbKR4vp0ya", // P@ssw0rd
                        Status = UserStatus.ACTIVE,
                    }
                );

            context.SaveChanges();

            Console.WriteLine("Seeded users");
        }

        public static void SeedTournaments(ApplicationDbContext context)
        {
            context.Tournament
                .AddRange(
                    new Tournament
                    {
                        Name = "ESL One Cologne 2025",
                        UserId = 1,
                        TournamentType = TournamentType.HYBRID,
                        Status = TournamentStatus.LIVE,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(5),
                        PrizePool = 1000000,
                        ParticipantSize = 16,
                        PrizePoolCurrency = "USD",
                    }
                );
            
            context.SaveChanges();

            context.TournamentStage
                .AddRange(
                    new TournamentStage
                    {
                        TournamentId = 1,
                        StageName = "Group Stage",
                        StageOrder = 0,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(7),
                        Status = StageStatus.ACTIVE,
                        StageFormat = StageFormat.GROUP_STAGE_DOUBLE
                    },
                    new TournamentStage
                    {
                        TournamentId = 1,
                        StageName = "Playoffs",
                        StageOrder = 1,
                        StartDate = DateTime.UtcNow.AddDays(3),
                        EndDate = DateTime.UtcNow.AddDays(5),
                        Status = StageStatus.ACTIVE,
                        StageFormat = StageFormat.DOUBLE_ELIMINATION
                    }
                );
            
            context.SaveChanges();
        }
        public static void SeedTeams(ApplicationDbContext context)
        {
            context.Team
                .AddRange(
                    new Team
                    {
                        Name = "Astralis",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "Natus Vincere",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "Team Liquid",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "G2 Esports",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "FaZe Clan",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "Fnatic",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "Virtus.pro",
                        tournamentId = 1,
                    },
                    new Team
                    {
                        Name = "BIG",
                        tournamentId = 1,
                    }
                );
            
            context.SaveChanges();
        }
    }
}