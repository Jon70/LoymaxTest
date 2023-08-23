using LoymaxTest.Services.Auth;
using LoymaxTest.Services.Interfaces;
using MediatR;

namespace LoymaxTest.Application.Commands.Auth
{
    /// <summary>
    /// Обработчик для создания токена
    /// </summary>
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, AuthToken>
    {
        private readonly ITokenService _tokenService;

        public CreateTokenCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public Task<AuthToken> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tokenService.Authenticate(request.Id, request.Login));
        }
    }
}
