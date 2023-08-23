using LoymaxTest.Application.Common.Exceptions;
using LoymaxTest.Application.Interfaces;
using LoymaxTest.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Commands.Finance
{
    /// <summary>
    /// Обработчик для перевода активов
    /// </summary>
    public class TransferCommandHandler : IRequestHandler<TransferCommand, Unit>
    {
        private readonly IBankDbContext _dbContext;

        public TransferCommandHandler(IBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            var amount = request.Amount;
            var userFrom = await _dbContext.Users
                .Include(u => u.Account)
                .FirstAsync(l => l.Id == request.UserIdFrom, cancellationToken);
            var userTo = await _dbContext.Users
                .Include(u => u.Account)
                .FirstOrDefaultAsync(l => l.Login == request.LoginTo, cancellationToken);

            if (userTo == null)
            {
                throw new NotFoundException($"Login {request.LoginTo}");
            }

            var accountFrom = userFrom.Account;
            var accountTo = userTo.Account;

            if (accountFrom.Balance < amount)
            {
                throw new NotEnoughFundsException("Недостаточно средств.");
            }

            accountFrom.Balance -= amount;
            accountFrom.ConcurrencyToken = Guid.NewGuid();
            accountTo.Balance += amount;
            accountTo.ConcurrencyToken = Guid.NewGuid();

            var saved = false;

            while (!saved)
            {
                try
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Account entity)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = await entry.GetDatabaseValuesAsync(cancellationToken);

                            foreach (var property in proposedValues.Properties)
                            {
                                if (property.Name == "Balance")
                                {
                                    var databaseValue = (decimal)(databaseValues?[property] ?? throw new InvalidOperationException());

                                    proposedValues[property] = entity.Id == accountFrom.Id
                                        ? databaseValue - amount
                                        : databaseValue + amount;
                                }
                            }

                            if (databaseValues != null)
                                entry.OriginalValues.SetValues(databaseValues);
                        }
                    }
                }

            }

            return Unit.Value;
        }
    }
}
