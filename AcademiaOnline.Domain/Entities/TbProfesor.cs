using AcademiaOnline.Domain.Common;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbProfesor : BaseEntity
    {
        public TbProfesor()
        {
            TbProfesorMateria = new HashSet<TbProfesorMateria>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<TbProfesorMateria> TbProfesorMateria { get; set; }

    }
}
