using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AddSeleccionMateria
{

    public record AddSeleccionMateriaCommand(int EstudianteId, List<int> MateriaIds) : IRequest<bool>;

}
