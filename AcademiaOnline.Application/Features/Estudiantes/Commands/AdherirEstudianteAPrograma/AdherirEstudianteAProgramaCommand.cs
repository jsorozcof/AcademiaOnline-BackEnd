using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma
{
    public record AdherirEstudianteAProgramaCommand(int EstudianteId, int ProgramaId) : IRequest<AdherirEstudianteAProgramaDto>;

}
