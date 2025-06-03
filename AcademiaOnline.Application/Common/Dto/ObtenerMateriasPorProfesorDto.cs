namespace AcademiaOnline.Application.Common.Dto
{
    public class ObtenerMateriasPorProfesorDto
    {
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorNombre { get; set; } = string.Empty;
        public string NombreMateria { get; set; } = string.Empty;
    }
}
