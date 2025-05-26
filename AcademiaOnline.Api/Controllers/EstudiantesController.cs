using AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma;
using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;
using AcademiaOnline.Application.Features.Estudiantes.Queries.GetAllEstudiantes;
using AcademiaOnline.Application.Features.Estudiantes.Queries.GetEstudiantesPorMateria;
using AcademiaOnline.Application.Features.Estudiantes.Queries.GetValidateProfesorEstudiante;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaOnline.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstudiantesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registra un nuevo estudiante
        /// </summary>
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarEstudiante([FromBody] RegisterEstudianteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene los nombres de los estudiantes en una materia específica (excepto el mismo estudiante)
        /// </summary>
        [HttpGet("{estudianteId}/materia/{materiaId}/estidiantes")]
        public async Task<IActionResult> GetEstudiantesPorMateria(int estudianteId, int materiaId)
        {
            var result = await _mediator.Send(new GetEstudiantesPorMateriaQuery(estudianteId, materiaId));
            return Ok(result);
        }

        [HttpGet("ObtenerEstudiantes")]
        public async Task<IActionResult> ObtenerEstudiantes()
        {
            var result = await _mediator.Send(new GetAllEstudiantesQuery());
            return Ok(result);
        }


        [HttpGet("validar-profesor")]
        public async Task<IActionResult> ValidarProfesor([FromQuery] int estudianteId, [FromQuery] int profesorId)
        {
            var result = await _mediator.Send(new ValidateProfesorEstudianteQuery(estudianteId, profesorId));
            return Ok(result);
        }

        [HttpPost("adhesion")]
        public async Task<IActionResult> AdherirEstudianteAPrograma([FromBody] AdherirEstudianteAProgramaCommand command)
        {
            var resultado = await _mediator.Send(command);
            return resultado ? Ok("Estudiante adherido exitosamente") : BadRequest("Error en la adhesión");
        }
    }
}
