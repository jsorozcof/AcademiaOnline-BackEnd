using AcademiaOnline.Domain.Common;
using System;
using System.Collections.Generic;

namespace AcademiaOnline.Domain.Entities
{
    public partial class TbEstudiantePrograma : BaseEntity
    {
        public int EstudianteId { get; set; }
        public int ProgramaId { get; set; }

        public virtual TbEstudiante Estudiante { get; set; } = null!;
        public virtual TbProgramasCredito Programa { get; set; } = null!;

    }
}
