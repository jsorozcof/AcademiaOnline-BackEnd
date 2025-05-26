using AcademiaOnline.Application.Features.Materias.Queries.GetAllMaterias;
using AcademiaOnline.Application.Features.Materias.Queries.GetProfMaterias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaOnline.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MateriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSubjectsWithProfessors")]
        public async Task<IActionResult> GetSubjectsWithProfessors()
        {
            var result = await _mediator.Send(new GetProfMateriasQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _mediator.Send(new GetAllMateriasQuery());
            return Ok(result);
        }

    }

}
