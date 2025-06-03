using AcademiaOnline.Application.Common.Dto;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetProfMaterias
{
    public record GetProfMateriasQuery : IRequest<IEnumerable<ObtenerMateriasPorProfesorDto>>;
}
