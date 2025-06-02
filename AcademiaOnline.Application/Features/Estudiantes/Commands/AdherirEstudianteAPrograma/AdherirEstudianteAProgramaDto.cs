namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma
{
    public class AdherirEstudianteAProgramaDto
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public string? Programa { get; set; } = string.Empty;

    }
}
