using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbProfesorMaterium
    {
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public int MateriaId { get; set; }

        public virtual TbMateria Materia { get; set; } = null!;
        public virtual TbProfesore Profesor { get; set; } = null!;
    }
}
