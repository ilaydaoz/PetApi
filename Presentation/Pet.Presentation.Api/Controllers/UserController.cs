using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;
using Shared.Pet.Controllers;

namespace Pet.Presentation.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] UserInsertCommandRequestModel request) =>
           Ok(await _mediator.Send(request));
    }
}
