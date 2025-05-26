using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.Create
{

    public class RegisterEstudianteHandler : IRequestHandler<RegisterEstudianteCommand, AsignarCredAcademicosDto>
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriasService _materiasService;

        public RegisterEstudianteHandler(IEstudianteService estudianteService, IMateriasService materiasService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
            _materiasService = materiasService;
        }

        public async Task<AsignarCredAcademicosDto> Handle(RegisterEstudianteCommand request, CancellationToken cancellationToken)
        {
            // Validar materias y profesores
            var materias = await _materiasService.ObtenerPorIdAsync(1);

            var response = new AsignarCredAcademicosDto();
            //if (materias.Count != 3)
            //    throw new Exception("No se encontraron las 3 materias seleccionadas.");

            //var profesores = materias.Select(m => m.ProfesorId).Distinct();
            //if (profesores.Count() < 3)
            //    throw new Exception("No puede inscribirse a materias con el mismo profesor.");

            //// Crear entidad estudiante
            //var estudiante = new Estudiante
            //{
            //    Nombre = request.Nombre,
            //    DocumentoIdentidad = request.DocumentoIdentidad,
            //    Materias = materias.Select(m => new EstudianteMateria
            //    {
            //        MateriaId = m.Id
            //    }).ToList()
            //};

            //await _unitOfWork.Estudiantes.AddAsync(estudiante);
            //await _unitOfWork.SaveAsync();

            return response;
        }
    }
}
