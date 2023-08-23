using LoymaxTest.Services.Auth;

namespace LoymaxTest.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса по работе с токеном
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Получить токен аутентификации
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="id">Id</param>
        /// <returns>Токен</returns>
        AuthToken Authenticate(Guid id, string login);
    }
}
