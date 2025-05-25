using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetEstudiantesPorMateria
{
    public record GetEstudiantesPorMateriaQuery(int EstudianteId, int MateriaId) : IRequest<List<EstudiantesPorMateriaDto>>;
}
