namespace AcademiaOnline.Application.Features.Programas.Dtos
{
    public class GetAllProgramasCredDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos {  get; set; } = 0;
    }
}
