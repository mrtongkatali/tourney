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
                        Password = "$2a$11$xxSr0TbY8Z35dqCMe.mL3uZmwRys.n6ShpzMByo1PsmORKwgy0hZy",
                        Status = UserStatus.ACTIVE,
                    },
                    new User
                    {
                        Email = "user2@demo.com",
                        FirstName = "Two",
                        LastName = "User",
                        Password = "$2a$11$xxSr0TbY8Z35dqCMe.mL3uZmwRys.n6ShpzMByo1PsmORKwgy0hZy",
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