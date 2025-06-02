namespace AcademiaOnline.Application.Features.Auth.Commands.Login
{
    public class LoginAuthUsuarioDto
    {
        public string? NombreCompleto { get; set; }

        public string? UserId { get; set; }
        public int EstudianteId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? AccessToken { get; set; }
        public bool IsSuccess { get; set; }
        
    }
}
