using LoymaxTest.Domain.Models;
using LoymaxTest.Persistence;
using LoymaxTest.Services.Hashing;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Tests.Common
{
    internal class BankContextFactory
    {
        public static BankDbContext Create(DbContextOptions<BankDbContext> options)
        {
            var context = new BankDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }

        public static void Initialization(BankDbContext context)
        {
            var users = new List<User>();
            var hashingService = new HashingService();

            for (var index = 0; index < 2; index++)
            {
                var salt = hashingService.GetSalt();
                var saltedHashedPassword = hashingService.GetHash($"qwerty{index}", salt);

                users.Add(new User
                {
                    Id = Guid.Parse($"1476B620-FFF1-45EB-9E71-860DC76A588{index}"),
                    Login = $"user{index}",
                    FirstName = $"Иван{index}",
                    LastName = $"Иванов{index}",
                    Patronymic = $"Иванович{index}",
                    DateOfBirth = new DateTime(),
                    Salt = salt,
                    SaltedHashedPassword = saltedHashedPassword,
                    Account = new Account
                    {
                        Balance = 1000,
                        Id = Guid.NewGuid(),
                        ConcurrencyToken = Guid.NewGuid()
                    }
                });
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static void Destroy(BankDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
