using AcademiaOnline.Domain.Common;
using System;
using System.Collections.Generic;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbMateria : BaseEntity
    {
        public TbMateria()
        {
            TbEstudianteMateria = new HashSet<TbEstudianteMateria>();
            TbProfesorMateria = new HashSet<TbProfesorMateria>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int? Creditos { get; set; }

        public virtual ICollection<TbEstudianteMateria> TbEstudianteMateria { get; set; }
        public virtual ICollection<TbProfesorMateria> TbProfesorMateria { get; set; }
    }
}
