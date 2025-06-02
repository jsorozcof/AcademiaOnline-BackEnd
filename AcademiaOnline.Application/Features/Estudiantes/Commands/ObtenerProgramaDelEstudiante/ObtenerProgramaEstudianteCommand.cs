using AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.ObtenerProgramaDelEstudiante
{

    public record ObtenerProgramaEstudianteCommand(int EstudianteId) : IRequest<ObtenerProgramaEstudianteDto>;

}
