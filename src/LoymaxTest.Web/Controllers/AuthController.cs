using LoymaxTest.Application.Queries.Auth;

namespace LoymaxTest.Web.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Guid>> SignUp([FromBody] CreateUserDto model)
        {
            var userId = await Mediator.Send(new CreateUserCommand
            {
                Login = model.Login,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic
            });

            return Created(userId.ToString(), userId);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] UserAuthDataModel model)
        {
            var user = await Mediator.Send(new GetUserByLoginQuery
            {
                Login = model.Login
            });

            var isPasswordCorrect = user != null ? await Mediator.Send(new CheckPasswordQuery
            {
                Password = model.Password,
                Salt = user.Salt,
                SaltedHashedPassword = user.SaltedHashedPassword
            }) : false;

            if (user == null || !isPasswordCorrect)
            {
                return Unauthorized("Неверный логин или пароль.");
            }

            var token = await Mediator.Send(new CreateTokenCommand
            {
                Login = user.Login,
                Id = user.Id
            });

            return Ok(token.Token);
        }

    }
}
