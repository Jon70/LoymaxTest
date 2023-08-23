using LoymaxTest.Services.Interfaces;
using MediatR;

namespace LoymaxTest.Application.Queries.Auth
{
    /// <summary>
    /// Обработчик для проверки пароля
    /// </summary>
    public class CheckPasswordQueryHandler : IRequestHandler<CheckPasswordQuery, bool>
    {
        private readonly IHashingService _hashingService;

        public CheckPasswordQueryHandler(IHashingService hashingService)
        {
            _hashingService = hashingService;
        }

        public Task<bool> Handle(CheckPasswordQuery request, CancellationToken cancellationToken)
        {
            var isEqual = _hashingService.Compare(request.Password + request.Salt, request.SaltedHashedPassword);

            return Task.FromResult(isEqual);
        }
    }
}
