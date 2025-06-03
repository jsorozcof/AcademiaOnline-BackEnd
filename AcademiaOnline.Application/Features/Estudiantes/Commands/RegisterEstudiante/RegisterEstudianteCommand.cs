using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante
{
    public class RegisterEstudianteCommand : IRequest<(bool, string)> 
    {
        public string Nombre { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
