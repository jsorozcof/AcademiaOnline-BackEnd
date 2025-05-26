using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetValidateProfesorEstudiante
{

    public class GetValidateProfesorEstudianteHandler : IRequestHandler<ValidateProfesorEstudianteQuery, bool>
    {
        private readonly IEstudianteService _estudianteService;

        public GetValidateProfesorEstudianteHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<bool> Handle(ValidateProfesorEstudianteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _estudianteService.TieneClaseConProfesorAsync(request.EstudianteId, request.ProfesorId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error validando si el estudiante ya tiene una clase con este profesor.", ex);
            }
        }
    }
}
