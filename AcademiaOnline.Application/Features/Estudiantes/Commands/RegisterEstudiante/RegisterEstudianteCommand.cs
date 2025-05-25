using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante
{
    public class RegisterEstudianteCommand : IRequest<int> 
    {
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<int> MateriaIds { get; set; } = new();
    }
}
