using MediatR;

namespace LoymaxTest.Application.Queries.Finance
{
    /// <summary>
    /// Запрос на проверку баланса
    /// </summary>
    public class BalanceCheckQuery : IRequest<decimal>
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid UserId { get; set; }
    }
}
