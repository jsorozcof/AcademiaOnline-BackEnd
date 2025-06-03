using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.GetMateriasInscritas
{
    public class GetMateriasInscritasHandler : IRequestHandler<GetMateriasInscritasCommand, List<MateriasInscritaDto>>
    {
        private readonly IEstudianteService _estudianteService;

        public GetMateriasInscritasHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<List<MateriasInscritaDto>> Handle(GetMateriasInscritasCommand request, CancellationToken cancellationToken)
        {
            return await _estudianteService.ObtenerMateriasInscritasAsync(request.EstudianteId);
        }
    }
}
