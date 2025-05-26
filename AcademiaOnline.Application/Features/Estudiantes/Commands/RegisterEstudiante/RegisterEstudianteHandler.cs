using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.Create
{

    public class RegisterEstudianteHandler : IRequestHandler<RegisterEstudianteCommand, bool>
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriasService _materiasService;

        public RegisterEstudianteHandler(IEstudianteService estudianteService, IMateriasService materiasService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
            _materiasService = materiasService;
        }

        public async Task<bool> Handle(RegisterEstudianteCommand request, CancellationToken cancellationToken)
        {
            var result = await _estudianteService.CrearAlumnoBasicAsync(request.Nombre, request.Email);
            return result;
        }
    }
}
