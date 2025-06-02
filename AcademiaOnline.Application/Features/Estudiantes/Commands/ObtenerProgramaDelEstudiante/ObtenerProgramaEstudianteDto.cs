namespace AcademiaOnline.Application.Features.Estudiantes.Commands.ObtenerProgramaDelEstudiante
{
    public class ObtenerProgramaEstudianteDto
    {
        public bool IsSuccess { get; set; }
        public string? Programa { get; set; } = string.Empty;
    }
}
