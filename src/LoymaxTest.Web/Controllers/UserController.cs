namespace LoymaxTest.Web.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetUserListQuery());

            return Ok(vm.Users);
        }

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Пользователь</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserListVm>> Get(Guid id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery
            {
                Id = id
            });

            return Ok(user);
        }
    }
}
