using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma
{
    public class AdherirEstudianteAProgramaHandler : IRequestHandler<AdherirEstudianteAProgramaCommand, bool>
    {
        private readonly IEstudianteService _estudianteService;

        public AdherirEstudianteAProgramaHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
        }

        public async Task<bool> Handle(AdherirEstudianteAProgramaCommand request, CancellationToken cancellationToken)
        {
            return await _estudianteService.AdherirEstudianteAProgramaAsync(request.EstudianteId, request.ProgramaId);
        }
    }
}
