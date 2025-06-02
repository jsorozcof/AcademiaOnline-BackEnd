using MediatR;

namespace AcademiaOnline.Application.Features.Auth.Commands.Login
{

    public class LoginCommand : IRequest<LoginAuthUsuarioDto>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
