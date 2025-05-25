using AcademiaOnline.Domain.Common;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbProfesorMateria : BaseEntity
    {
        public int ProfesorId { get; set; }
        public int MateriaId { get; set; }

        public virtual TbMateria Materia { get; set; } = null!;
        public virtual TbProfesor Profesor { get; set; } = null!;
    }
}
