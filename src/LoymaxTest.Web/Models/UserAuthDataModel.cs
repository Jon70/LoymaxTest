namespace LoymaxTest.Web.Models
{
    /// <summary>
    /// Модель аутентификации
    /// </summary>
    /// <param name="Login">Логин</param>
    /// <param name="Password">Пароль</param>
    public record UserAuthDataModel(string Login, string Password);
}
