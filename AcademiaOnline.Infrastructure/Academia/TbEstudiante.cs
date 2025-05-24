using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbEstudiante
    {
        public TbEstudiante()
        {
            TbEstudianteMateria = new HashSet<TbEstudianteMaterium>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProgramaCreditos { get; set; }

        public virtual TbEstudiantePrograma? TbEstudiantePrograma { get; set; }
        public virtual ICollection<TbEstudianteMaterium> TbEstudianteMateria { get; set; }
    }
}
