using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbProgramasCredito
    {
        public TbProgramasCredito()
        {
            TbEstudianteProgramas = new HashSet<TbEstudiantePrograma>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int TotalCreditos { get; set; }

        public virtual ICollection<TbEstudiantePrograma> TbEstudianteProgramas { get; set; }
    }
}
