using LoymaxTest.Application.Commands.CreateUser;
using LoymaxTest.Application.Commands.Finance;
using LoymaxTest.Application.Interfaces;
using LoymaxTest.Services.Hashing;
using LoymaxTest.Tests.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LoymaxTest.Domain.Models;

namespace LoymaxTest.Tests
{
    public class FinanceApiTests : TestCommandBase
    {
        #region Private

        private readonly Random _random = new();

        private async Task ProcessTransactions(IReadOnlyList<User> users, IBankDbContext context)
        {
            var handler = new TransferCommandHandler(context);

            for (var index = 0; index < 5; index++)
            {
                var loginTo = $"user{_random.Next(0, 50)}";
                var userIdFrom = users[index].Id;
                var amount = 500;

                var task = await handler.Handle
                (
                    new TransferCommand
                    {
                        LoginTo = loginTo,
                        UserIdFrom = userIdFrom,
                        Amount = amount
                    }, default
                );

                Assert.IsType<Unit>(task);
            }
        }

        private async Task RegisterUsers()
        {
            var handler = new CreateUserCommandHandler(Context, new HashingService());

            for (var index = 2; index < 50; index++)
            {
                var login = $"user{index}";
                var firstName = $"Иван{index}";
                var lastName = $"Иванов{index}";
                var patronymic = $"Иванович{index}";
                var dateOfBirth = "10/01/1994";
                var password = $"qwerty{index}";

                var userId = await handler.Handle
                (
                    new CreateUserCommand
                    {
                        Login = login,
                        FirstName = firstName,
                        LastName = lastName,
                        Patronymic = patronymic,
                        DateOfBirth = dateOfBirth,
                        Password = password
                    }, default
                );

                Assert.IsType<Guid>(userId);
            }
        }

        #endregion

        [Fact]
        public async Task Multithreaded_Transactions_Test()
        {
            await RegisterUsers();
            var users = await Context.Users.ToArrayAsync();

            var tasks = new List<Task>();

            for (var index = 0; index < 10; index++)
            {
                var firstIndex = index * 5;
                var lastIndex = firstIndex + 5;

                tasks.Add(Task.Run(() => ProcessTransactions(users[firstIndex..lastIndex], CreateContext())));
            }

            await Task.WhenAll(tasks);
        }
    }
}
