namespace AcademiaOnline.Application.Features.Materias.Dtos
{
    public class ProfMateriasDto
    {
        public int MateriaId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string NombreMateria { get; set; } = string.Empty;

        public int ProfesorId { get; set; }
    }
}
