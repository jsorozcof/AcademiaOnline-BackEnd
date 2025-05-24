using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbMateria
    {
        public TbMateria()
        {
            TbEstudianteMateria = new HashSet<TbEstudianteMaterium>();
            TbProfesorMateria = new HashSet<TbProfesorMaterium>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int? Creditos { get; set; }

        public virtual ICollection<TbEstudianteMaterium> TbEstudianteMateria { get; set; }
        public virtual ICollection<TbProfesorMaterium> TbProfesorMateria { get; set; }
    }
}
