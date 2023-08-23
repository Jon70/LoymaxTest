namespace LoymaxTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator
            => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>()) ?? throw new InvalidOperationException();

        internal Guid UserId => !User.Identity!.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
    }
}
