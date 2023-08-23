using MediatR;

namespace LoymaxTest.Application.Commands.Finance
{
    /// <summary>
    /// Команда для перевода активов
    /// </summary>
    public class TransferCommand : IRequest<Unit>
    {
        /// <summary>
        /// Логин получателя
        /// </summary>
        public string LoginTo { get; set; }

        /// <summary>
        /// Id отправителя
        /// </summary>
        public Guid UserIdFrom { get; set; }

        /// <summary>
        /// Сумма, руб
        /// </summary>
        public decimal Amount { get; set; }
    }
}
