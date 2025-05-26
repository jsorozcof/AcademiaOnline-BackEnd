namespace AcademiaOnline.Application.Features.Estudiantes.Dtos
{
    public class GetAllEstudiantesDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Programa_Creditos { get; set; }
        public string Email { get; set; } = string.Empty;
        
        public int Programa_Id { get; set; }
        public string NombrePrograma { get; set; } = string.Empty;
    }
}
