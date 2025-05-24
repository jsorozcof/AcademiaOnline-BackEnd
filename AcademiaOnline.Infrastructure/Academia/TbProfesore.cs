using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbProfesore
    {
        public TbProfesore()
        {
            TbProfesorMateria = new HashSet<TbProfesorMaterium>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<TbProfesorMaterium> TbProfesorMateria { get; set; }
    }
}
