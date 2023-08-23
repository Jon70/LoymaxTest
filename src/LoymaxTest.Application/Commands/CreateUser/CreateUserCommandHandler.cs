using LoymaxTest.Application.Common.Exceptions;
using LoymaxTest.Application.Interfaces;
using LoymaxTest.Domain.Models;
using LoymaxTest.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Commands.CreateUser
{
    /// <summary>
    /// Обработчик для создания пользователя
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IBankDbContext _dbContext;
        private readonly IHashingService _hashingService;

        public CreateUserCommandHandler(IBankDbContext dbContext, IHashingService hashingService)
        {
            _dbContext = dbContext;
            _hashingService = hashingService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDb = await _dbContext.Users
                .FirstOrDefaultAsync(l => l.Login == request.Login, cancellationToken);

            if (userDb != null)
            {
                throw new UserRegisteredException("Пользователь с таким логином уже зарегистрирован.");
            }

            var salt = _hashingService.GetSalt();
            var saltedHashedPassword = _hashingService.GetHash(request.Password, salt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                DateOfBirth = DateTime.Parse(request.DateOfBirth),
                Login = request.Login,
                SaltedHashedPassword = saltedHashedPassword,
                Salt = salt,
                Account = new Account
                {
                    Id = Guid.NewGuid(),
                    Balance = 1000,
                    ConcurrencyToken = Guid.NewGuid()
                }
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
