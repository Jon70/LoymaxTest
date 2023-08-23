using FluentValidation;

namespace LoymaxTest.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(model =>
                model.Login).NotEmpty().MinimumLength(5).MaximumLength(15);
            RuleFor(model =>
                model.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(model =>
                model.LastName).NotEmpty().MaximumLength(50);
            RuleFor(model =>
                model.Patronymic).NotEmpty().MaximumLength(50);
            RuleFor(model =>
                model.Password).NotEmpty().MinimumLength(6);
            RuleFor(model =>
                model.DateOfBirth).NotEmpty().MinimumLength(8).Must(BeAValidDate);
        }

        private static bool BeAValidDate(string dateString)
            => DateTime.TryParse(dateString, out var date) && DateTime.Now.Year - date.Year >= 18;
    }
}
