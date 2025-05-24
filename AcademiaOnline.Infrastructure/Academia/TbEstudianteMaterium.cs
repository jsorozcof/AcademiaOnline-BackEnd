using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbEstudianteMaterium
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }

        public virtual TbEstudiante Estudiante { get; set; } = null!;
        public virtual TbMateria Materia { get; set; } = null!;
    }
}
