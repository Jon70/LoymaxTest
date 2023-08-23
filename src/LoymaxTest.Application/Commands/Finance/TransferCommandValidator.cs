using FluentValidation;

namespace LoymaxTest.Application.Commands.Finance
{
    public class TransferCommandValidator : AbstractValidator<TransferCommand>
    {
        public TransferCommandValidator()
        {
            RuleFor(model =>
                model.Amount).NotEmpty();
            RuleFor(model =>
                model.LoginTo).NotEmpty();
            RuleFor(model =>
                model.UserIdFrom).NotEqual(Guid.Empty);
        }
    }
}
