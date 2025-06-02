using AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma;
using AcademiaOnline.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaOnline.Application.Features.Estudiantes.Commands.ObtenerProgramaDelEstudiante
{

    public class ObtenerProgramaEstudianteHandlermaHandler : IRequestHandler<ObtenerProgramaEstudianteCommand, ObtenerProgramaEstudianteDto>
    {
        private readonly IEstudianteService _estudianteService;

        public ObtenerProgramaEstudianteHandlermaHandler(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
        }

        public async Task<ObtenerProgramaEstudianteDto> Handle(ObtenerProgramaEstudianteCommand request, CancellationToken cancellationToken)
        {
           var response = await _estudianteService.ObtenerProgramaDelEstudianteAsync(request.EstudianteId);
            return new ObtenerProgramaEstudianteDto
            {
                IsSuccess = response.Item1,
                Programa = response.Item2
            };
        }
    }

}
