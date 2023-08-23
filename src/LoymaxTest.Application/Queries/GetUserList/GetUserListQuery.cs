using MediatR;

namespace LoymaxTest.Application.Queries.GetUserList
{
    /// <summary>
    /// Запрос на получение всех пользователей
    /// </summary>
    public class GetUserListQuery : IRequest<UserListVm>
    {
    }
}
