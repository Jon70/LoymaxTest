using LoymaxTest.Application.Queries.GetUser;

namespace LoymaxTest.Application.Queries.GetUserList
{
    /// <summary>
    /// Vm пользователей
    /// </summary>
    /// <param name="Users">Пользователи</param>
    public record UserListVm(IEnumerable<UserLookupDto> Users);
}
