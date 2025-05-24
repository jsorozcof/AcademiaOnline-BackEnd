using System;
using System.Collections.Generic;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class TbEstudiantePrograma
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int ProgramaId { get; set; }

        public virtual TbEstudiante Estudiante { get; set; } = null!;
        public virtual TbProgramasCredito Programa { get; set; } = null!;
    }
}
