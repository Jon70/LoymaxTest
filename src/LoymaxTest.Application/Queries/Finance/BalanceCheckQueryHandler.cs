using LoymaxTest.Application.Common.Exceptions;
using LoymaxTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Queries.Finance
{
    /// <summary>
    /// Обработчик для проверки баланса
    /// </summary>
    public class BalanceCheckQueryHandler : IRequestHandler<BalanceCheckQuery, decimal>
    {
        private readonly IBankDbContext _dbContext;

        public BalanceCheckQueryHandler(IBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> Handle(BalanceCheckQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(u => u.Account)
                .FirstOrDefaultAsync(l => l.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException($"Id {request.UserId}");
            }

            return user.Account.Balance;
        }
    }
}
