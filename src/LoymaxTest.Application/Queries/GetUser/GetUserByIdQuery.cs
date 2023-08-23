using MediatR;

namespace LoymaxTest.Application.Queries.GetUser
{
    /// <summary>
    /// Запрос для получения пользователя по id
    /// </summary>
    public class GetUserByIdQuery : IRequest<UserLookupDto>
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
