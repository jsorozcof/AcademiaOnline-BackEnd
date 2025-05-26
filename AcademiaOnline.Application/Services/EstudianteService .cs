using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;
using MediatR;

namespace AcademiaOnline.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;
        //private readonly IProgramaCreditoRepository _programaCreditoRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository) //IProgramaCreditoRepository programaCreditoRepository
        {
            _estudianteRepository = estudianteRepository ?? throw new ArgumentNullException(nameof(estudianteRepository));
            //_programaCreditoRepository = programaCreditoRepository ?? throw new ArgumentNullException(nameof(programaCreditoRepository));
        }

        public async Task<bool> AdherirEstudianteAProgramaAsync(int estudianteId, int programaId)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(estudianteId);
            if (estudiante == null)
                throw new Exception("El estudiante no existe.");

            //var programa = await _programaCreditoRepository.GetByIdAsync(programaId);
            //if (programa == null)
            //    throw new Exception("El programa de créditos no existe.");

            if (await _estudianteRepository.EstudianteYaTieneProgramaAsync(estudianteId))
                throw new Exception("El estudiante ya está adherido a un programa de créditos.");

            var nuevaAdhesion = new TbEstudiantePrograma
            {
                EstudianteId = estudianteId,
                ProgramaId = programaId
            };

            await _estudianteRepository.AddProgramaAsync(nuevaAdhesion);
            await _estudianteRepository.SaveChangesAsync();

            return true;
        }



        public async Task<List<GetAllEstudiantesDto>> ObtenerEstudiantesAsync()
        {
            var estudiante = await _estudianteRepository.ObtenerEstudiantesAsync();
            if (estudiante == null)
                throw new Exception("No se encontraron registros.");

            return estudiante;
        }

        public async Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(estudianteId);
            if (estudiante == null)
                throw new Exception("El estudiante no existe.");

            var tieneClase = await _estudianteRepository.TieneClaseConProfesorAsync(estudianteId, profesorId);
            
            return tieneClase;

        }
    }
}
