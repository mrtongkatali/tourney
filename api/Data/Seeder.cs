using tourney.api.Models;

namespace tourney.api.Data
{
    public class Seeder
    {
        public static void SeedAll(ApplicationDbContext context)
        {
            SeedUsers(context);
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
                        Status = Models.UserStatus.ACTIVE,
                    },
                    new User
                    {
                        Email = "user2@demo.com",
                        FirstName = "Two",
                        LastName = "User",
                        Password = "$2a$11$xxSr0TbY8Z35dqCMe.mL3uZmwRys.n6ShpzMByo1PsmORKwgy0hZy",
                        Status = Models.UserStatus.ACTIVE,
                    }
                );

            context.SaveChanges();
        }

        // public static void SeedTournaments(ApplicationDbContext context)
        // {
        //     context.Tournament
        //         .AddRange(
        //             new Tournament
        //             {
        //                 Name = "Tournament 1",
        //                 UserId = 1,
        //                 // Status = Models.Tournament.,
        //             },
        //         )
        // }
    }
}