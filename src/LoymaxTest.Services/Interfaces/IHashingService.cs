namespace LoymaxTest.Services.Interfaces
{
    public interface IHashingService
    {
        /// <summary>
        /// Сравнение хэшей
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="hash">Хэш</param>
        /// <returns></returns>
        bool Compare(string value, string hash);

        /// <summary>
        /// Генерация соли
        /// </summary>
        /// <returns>Соль</returns>
        string GetSalt();

        /// <summary>
        /// Получить хэш строки
        /// </summary>
        /// <param name="value">Входная строка</param>
        /// <param name="salt">Соль</param>
        /// <returns>Хэш</returns>
        string GetHash(string value, string? salt = null);
    }
}
