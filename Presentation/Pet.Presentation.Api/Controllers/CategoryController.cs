using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Core.Application.Services.Commands.Insert.Category;
using Shared.Pet.Controllers;

namespace Pet.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CategoryInsertCommandRequestModel request) =>
          Ok(await _mediator.Send(request));
    }
}
