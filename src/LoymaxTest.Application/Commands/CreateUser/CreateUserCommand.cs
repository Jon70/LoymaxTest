using MediatR;

namespace LoymaxTest.Application.Commands.CreateUser
{
    /// <summary>
    /// Команда для создания пользователя
    /// </summary>
    public class CreateUserCommand : CreateUserDto, IRequest<Guid>
    {
    }
}
