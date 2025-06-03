using AcademiaOnline.Application.Common.Dto;
using AcademiaOnline.Application.Features.Materias.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetProfMaterias
{

    public class GetProfMateriasHandler : IRequestHandler<GetProfMateriasQuery, IEnumerable<ObtenerMateriasPorProfesorDto>>
    {
        private readonly IMateriasService _materiasService;

        public GetProfMateriasHandler(IMateriasService materiasService)
        {
            _materiasService = materiasService;
        }

        public async Task<IEnumerable<ObtenerMateriasPorProfesorDto>> Handle(GetProfMateriasQuery request, CancellationToken cancellationToken)
        {
            return await _materiasService.ObtenerMateriasPorProfesor();
        }
    }

}
