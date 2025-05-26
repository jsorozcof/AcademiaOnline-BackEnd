using AcademiaOnline.Application.Features.Materias.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetProfMaterias
{

    public class GetProfMateriasHandler : IRequestHandler<GetProfMateriasQuery, List<ProfMateriasDto>>
    {
        private readonly IMateriasService _materiasService;

        public GetProfMateriasHandler(IMateriasService materiasService)
        {
            _materiasService = materiasService;
        }

        public async Task<List<ProfMateriasDto>> Handle(GetProfMateriasQuery request, CancellationToken cancellationToken)
        {
            var list = await _materiasService.ObtenerMateriasProfesoresAsync();

            var result = list.Select(x => new ProfMateriasDto { MateriaId = x.Id, NombreMateria = x.Nombre }).ToList();

            return result;
        }
    }

}
