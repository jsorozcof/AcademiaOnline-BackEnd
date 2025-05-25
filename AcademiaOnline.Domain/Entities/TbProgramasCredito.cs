using AcademiaOnline.Domain.Common;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbProgramasCredito : BaseEntity
    {
        public TbProgramasCredito()
        {
            TbEstudianteProgramas = new HashSet<TbEstudiantePrograma>();
        }

        public string Nombre { get; set; } = null!;
        public int TotalCreditos { get; set; }

        public virtual ICollection<TbEstudiantePrograma> TbEstudianteProgramas { get; set; }
    }
}
