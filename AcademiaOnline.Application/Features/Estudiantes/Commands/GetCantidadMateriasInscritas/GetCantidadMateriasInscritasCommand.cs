using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.GetCantidadMateriasInscritas
{
    public record GetCantidadMateriasInscritasCommand(int EstudianteId) : IRequest<int>;

}
