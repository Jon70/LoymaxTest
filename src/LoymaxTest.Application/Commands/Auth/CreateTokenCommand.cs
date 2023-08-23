using LoymaxTest.Services.Auth;
using MediatR;

namespace LoymaxTest.Application.Commands.Auth
{
    /// <summary>
    /// Команда для создания токена
    /// </summary>
    public class CreateTokenCommand : IRequest<AuthToken>
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
