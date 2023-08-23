using MediatR;

namespace LoymaxTest.Application.Queries.Auth
{
    /// <summary>
    /// Запрос для проверки пароля
    /// </summary>
    public class CheckPasswordQuery : IRequest<bool>
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Соль
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Пароль с солью
        /// </summary>
        public string SaltedHashedPassword { get; set; }
    }
}
