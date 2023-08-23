using FluentValidation;

namespace LoymaxTest.Application.Queries.Finance
{
    public class BalanceCheckQueryValidator : AbstractValidator<BalanceCheckQuery>
    {
        public BalanceCheckQueryValidator()
        {
            RuleFor(model => model.UserId).NotEqual(Guid.Empty);
        }
    }
}
