using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetAllEstudiantes
{

    public record GetAllEstudiantesQuery() : IRequest<List<GetAllEstudiantesDto>>;

}
