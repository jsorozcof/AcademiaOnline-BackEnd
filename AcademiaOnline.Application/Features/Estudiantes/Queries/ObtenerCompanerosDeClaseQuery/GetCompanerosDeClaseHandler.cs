using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.ObtenerCompanerosDeClaseQuery
{

    public class GetCompanerosDeClaseHandler : IRequestHandler<GetCompanerosDeClaseQuery, IEnumerable<EstudianteCompaneroDto>>
    {
        private readonly IEstudianteService _estudianteService;

        public GetCompanerosDeClaseHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<IEnumerable<EstudianteCompaneroDto>> Handle(GetCompanerosDeClaseQuery request, CancellationToken cancellationToken)
        {
            return await _estudianteService.GetCompanerosDeClaseAsync(request.EstudianteId);
        }
    }
}
