using LoymaxTest.Application.Commands.CreateUser;
using LoymaxTest.Services.Hashing;
using LoymaxTest.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LoymaxTest.Tests.Commands
{
    public class CreateUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_CreateUser_UserIsCreated()
        {
            var handler = new CreateUserCommandHandler(Context, new HashingService());
            var login = "user100";
            var firstName = "Иван";
            var lastName = "Иванов";
            var patronymic = "Иванович";
            var dateOfBirth = "10/01/1994";
            var password = "qwerty";

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

            var user = await Context.Users.SingleOrDefaultAsync(p => p.Id == userId);

            Assert.NotNull(user);
            Assert.Equal(login, user.Login);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(lastName, user.LastName);
        }
    }
}
