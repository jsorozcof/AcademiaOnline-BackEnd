using AcademiaOnline.Application.Interfaces;
using MediatR;
using System.Runtime.Intrinsics.X86;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma
{
    public class AdherirEstudianteAProgramaHandler : IRequestHandler<AdherirEstudianteAProgramaCommand, AdherirEstudianteAProgramaDto>
    {
        private readonly IEstudianteService _estudianteService;

        public AdherirEstudianteAProgramaHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
        }

        public async Task<AdherirEstudianteAProgramaDto> Handle(AdherirEstudianteAProgramaCommand request, CancellationToken cancellationToken)
        {
            var response = await _estudianteService.AdherirEstudianteAProgramaAsync(request.EstudianteId, request.ProgramaId);
            return new AdherirEstudianteAProgramaDto
            {
                IsSuccess = response.Item1,
                Message = response.Item2,
                Programa = response.Item3
            };
        }
    }
}
