using AcademiaOnline.Application.Features.Materias.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetAllMaterias
{

    public class GetAllMateriasHandler : IRequestHandler<GetAllMateriasQuery, List<MateriasDto>>
    {
        private readonly IMateriasService _materiasService;

        public GetAllMateriasHandler(IMateriasService materiasService)
        {
            _materiasService = materiasService;
        }

        public async Task<List<MateriasDto>> Handle(GetAllMateriasQuery request, CancellationToken cancellationToken)
        {
            var list = await _materiasService.ObtenerTodasAsync();

            var result = list.Select(x => new MateriasDto {  Id = x.Id, Nombre = x.Nombre }).ToList();

            return result;
        }
    }
}
