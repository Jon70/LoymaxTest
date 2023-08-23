using LoymaxTest.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace LoymaxTest.Services.Hashing
{
    public class HashingService : IHashingService
    {
        /// <summary>
        /// Сравнение хэшей
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="hash">Хэш</param>
        /// <returns>bool</returns>
        public bool Compare(string value, string hash)
            => 0 == StringComparer.OrdinalIgnoreCase.Compare(GetHash(value), hash);

        /// <summary>
        /// Генерация соли
        /// </summary>
        /// <returns>Соль</returns>
        public string GetSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];

            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Получить хэш строки
        /// </summary>
        /// <param name="value">Входная строка</param>
        /// <param name="salt">Соль</param>
        /// <returns>Хэш</returns>
        public string GetHash(string value, string? salt = null)
        {
            using var hash = SHA256.Create();
            var saltedValue = value + salt;

            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(saltedValue)));
        }
    }
}
