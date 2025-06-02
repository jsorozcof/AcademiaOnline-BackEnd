using MediatR;

namespace AcademiaOnline.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Nombre { get; set; } = default!;
        public string Correo { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
