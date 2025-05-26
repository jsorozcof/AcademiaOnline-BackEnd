using AcademiaOnline.Application.Features.Programas.Queries.GetAllProgramas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaOnline.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaCreditoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramaCreditoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCreditProgram()
        {
            var result = await _mediator.Send(new GetAllProgCredQuery());
            return Ok(result);
        }

    }

}
