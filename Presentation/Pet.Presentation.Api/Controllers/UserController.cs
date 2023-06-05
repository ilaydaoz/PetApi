using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Core.Application.Services.Commands.Insert.Users.Login;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;
using Shared.Pet.Controllers;

namespace Pet.Presentation.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Register([FromBody] LoginUserCommandRequestModel request) =>
       Ok(await _mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserInsertCommandRequestModel request) =>
           Ok(await _mediator.Send(request));

    }
}
