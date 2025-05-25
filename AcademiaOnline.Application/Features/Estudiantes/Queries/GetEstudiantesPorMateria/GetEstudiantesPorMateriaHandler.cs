using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Estudiantes.Queries.GetEstudiantesPorMateria
{

    public class GetEstudiantesPorMateriaHandler : IRequestHandler<GetEstudiantesPorMateriaQuery, List<EstudiantesPorMateriaDto>>
    {
        private readonly IEstudianteRepository _repository;

        public GetEstudiantesPorMateriaHandler(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EstudiantesPorMateriaDto>> Handle(GetEstudiantesPorMateriaQuery request, CancellationToken cancellationToken)
        {
            var estudiantes = await _repository.GetEstudiantesPorMateriaAsync(request.EstudianteId, request.MateriaId);

            var result = estudiantes
                        .Select(x => new EstudiantesPorMateriaDto {
                            NombreAlumno = x.Nombre 
                        }).ToList();

            return result;
        }
    }
}
