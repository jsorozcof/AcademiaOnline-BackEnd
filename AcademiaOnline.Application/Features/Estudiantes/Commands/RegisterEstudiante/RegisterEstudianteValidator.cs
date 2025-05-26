using FluentValidation;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante
{
    public class RegisterEstudianteValidator : AbstractValidator<RegisterEstudianteCommand>
    {
        public RegisterEstudianteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("El correo no puede estar vacío")
             .EmailAddress().WithMessage("El correo debe ser válido");

            //RuleFor(x => x.MateriaIds)
            //    .NotNull().WithMessage("Debe seleccionar materias.")
            //    .Must(m => m.Count == 3).WithMessage("Debe seleccionar exactamente 3 materias.");
        }
    }
}
