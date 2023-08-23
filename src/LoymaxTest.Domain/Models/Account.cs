namespace LoymaxTest.Domain.Models
{
    /// <summary>
    /// Лицевой счет клиента
    /// </summary>
    public class Account : EntityBase
    {
        /// <summary>
        /// Баланс
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }

        public Guid ConcurrencyToken { get; set; }
    }
}
