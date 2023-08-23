namespace LoymaxTest.Services.Configuration
{
    /// <summary>
    /// AppSettings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Ключ для генерации токена
        /// </summary>
        public string Key { get; init; }

        /// <summary>
        /// Длительность работы токена (в часах)
        /// </summary>
        public string Duration { get; init; }

    }
}
