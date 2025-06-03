using AcademiaOnline.Domain.Common;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbEstudiante : BaseEntity
    {
        public TbEstudiante()
        {
            TbEstudianteMateria = new HashSet<TbEstudianteMateria>();
        }

        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProgramaCreditos { get; set; }

        public virtual TbEstudiantePrograma? TbEstudiantePrograma { get; set; }
        public virtual ICollection<TbEstudianteMateria> TbEstudianteMateria { get; set; }
    }
}
