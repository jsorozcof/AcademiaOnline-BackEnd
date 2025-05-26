using AcademiaOnline.Application.Features.Programas.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;

namespace AcademiaOnline.Application.Features.Programas.Queries.GetAllProgramas
{

    public class GetAllProgCredHandler : IRequestHandler<GetAllProgCredQuery, List<GetAllProgramasCredDto>>
    {
        private readonly IProgramasCreditosService _progCredService;

        public GetAllProgCredHandler(IProgramasCreditosService progCredService)
        {
            _progCredService = progCredService;
        }

        public async Task<List<GetAllProgramasCredDto>> Handle(GetAllProgCredQuery request, CancellationToken cancellationToken)
        {
            var list = await _progCredService.ObtenerTodasAsync();

            var result = list.Select(x => new GetAllProgramasCredDto { Id = x.Id, Nombre = x.Nombre }).ToList();

            return result;
        }
    }

}
