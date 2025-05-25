using AcademiaOnline.Domain.Common;
using System;
using System.Collections.Generic;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbEstudianteMateria : BaseEntity
    {
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }

        public virtual TbEstudiante Estudiante { get; set; } = null!;
        public virtual TbMateria Materia { get; set; } = null!;
    }
}
