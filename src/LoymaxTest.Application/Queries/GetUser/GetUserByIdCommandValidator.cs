using FluentValidation;

namespace LoymaxTest.Application.Queries.GetUser
{
    public class GetUserCommandValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserCommandValidator()
        {
            RuleFor(model => model.Id).NotEqual(Guid.Empty);
        }
    }
}
