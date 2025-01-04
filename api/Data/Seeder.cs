namespace tourney.Data
{
    public class Seeder
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            context.User
                .AddRange(
                    new Models.User
                    {
                        Email = "user1@demo.com",
                        FirstName = "One",
                        LastName = "User",
                        Password = "$2a$11$xxSr0TbY8Z35dqCMe.mL3uZmwRys.n6ShpzMByo1PsmORKwgy0hZy",
                        Status = Models.UserStatus.ACTIVE,
                    },
                    new Models.User
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
    }
}