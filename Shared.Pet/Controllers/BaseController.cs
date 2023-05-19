using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Pet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
