using FluentValidation;

namespace LoymaxTest.Application.Queries.Auth
{
    public class CheckPasswordQueryValidator : AbstractValidator<CheckPasswordQuery>
    {
        public CheckPasswordQueryValidator()
        {
            RuleFor(model =>
                model.Password).NotEmpty();
            RuleFor(model =>
                model.Salt).NotEmpty().Length(24);
            RuleFor(model =>
                model.SaltedHashedPassword).NotEmpty().Length(64);
        }
    }
}
