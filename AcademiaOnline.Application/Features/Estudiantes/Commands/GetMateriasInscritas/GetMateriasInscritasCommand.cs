using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.GetMateriasInscritas
{

    public record GetMateriasInscritasCommand(int EstudianteId) : IRequest<List<MateriasInscritaDto>>;

}
