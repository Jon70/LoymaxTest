using FluentValidation;

namespace LoymaxTest.Application.Queries.GetUser
{
    public class GetUserByLoginCommandValidator : AbstractValidator<GetUserByLoginQuery>
    {
        public GetUserByLoginCommandValidator()
        {
            RuleFor(model => model.Login).NotEmpty();
        }
    }
}
