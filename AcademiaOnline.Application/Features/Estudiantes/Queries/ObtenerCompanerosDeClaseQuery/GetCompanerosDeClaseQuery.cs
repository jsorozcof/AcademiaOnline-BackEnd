using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.ObtenerCompanerosDeClaseQuery
{

    public record GetCompanerosDeClaseQuery(int EstudianteId) : IRequest<IEnumerable<EstudianteCompaneroDto>>;

}
