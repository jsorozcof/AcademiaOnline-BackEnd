using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AddSeleccionMateria
{

    public class AddSeleccionMateriaHandler : IRequestHandler<AddSeleccionMateriaCommand, bool>
    {
        private readonly IEstudianteService _estudianteService;

        public AddSeleccionMateriaHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
        }

        public async Task<bool> Handle(AddSeleccionMateriaCommand request, CancellationToken cancellationToken)
        {
            return await _estudianteService.SaveSelectedSubjectsAsync(request.MateriaIds, request.EstudianteId);
        }
    }
}
