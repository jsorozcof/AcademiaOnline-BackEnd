using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Features.Estudiantes.Queries.GetValidateProfesorEstudiante;
using AcademiaOnline.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetAllEstudiantes
{

    public class GetAllEstudiantesHandler : IRequestHandler<GetAllEstudiantesQuery, List<GetAllEstudiantesDto>>
    {
        private readonly IEstudianteService _estudianteService;

        public GetAllEstudiantesHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<List<GetAllEstudiantesDto>> Handle(GetAllEstudiantesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _estudianteService.ObtenerEstudiantesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: ", ex);
            }
        }
    }
}
