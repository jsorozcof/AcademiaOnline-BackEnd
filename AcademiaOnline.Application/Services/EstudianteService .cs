using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;
using MediatR;
using Microsoft.VisualBasic;

namespace AcademiaOnline.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository ?? throw new ArgumentNullException(nameof(estudianteRepository));
        }

        public async Task<bool> CrearAlumnoBasicAsync(string nombre, string email)
        {
            try
            {
                string codigoGen = CodeGenerator.GenerateCode();
                return await _estudianteRepository.AddAsync(codigoGen,nombre, email);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo guardar el alumno.", ex);
            }
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

        private class CodeGenerator
        {
            private static int currentNumber = 1115;

            public static string GenerateCode()
            {
                string code = $"A{currentNumber}";
                currentNumber++;
                return code;
            }
        }
    }
}
