namespace LoymaxTest.Domain.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Соль
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string SaltedHashedPassword { get; set; }

        /// <summary>
        /// Аккаунт
        /// </summary>
        public virtual Account Account { get; set; }
    }
}
