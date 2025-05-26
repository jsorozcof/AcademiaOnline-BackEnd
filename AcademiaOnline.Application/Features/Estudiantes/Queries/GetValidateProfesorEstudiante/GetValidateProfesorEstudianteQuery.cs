using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetValidateProfesorEstudiante
{
    public record ValidateProfesorEstudianteQuery(int EstudianteId, int ProfesorId) : IRequest<bool>;

}
