using MediatR;

namespace LoymaxTest.Application.Queries.GetUser
{
    /// <summary>
    /// Запрос для получения пользователя по логину
    /// </summary>
    public class GetUserByLoginQuery : IRequest<UserLookupDto>
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
    }
}
