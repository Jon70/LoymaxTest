using FluentValidation;

namespace LoymaxTest.Application.Commands.Auth
{
    public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(model =>
                model.Login).NotEmpty();
            RuleFor(model =>
                model.Id).NotEqual(Guid.Empty);
        }
    }
}
