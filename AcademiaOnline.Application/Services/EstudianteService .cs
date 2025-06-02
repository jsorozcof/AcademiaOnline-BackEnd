using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;

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

        public async Task<(bool, string, string)> AdherirEstudianteAProgramaAsync(int estudianteId, int programaId)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(estudianteId);
            if (estudiante == null)
                return (false, "El estudiante no existe.", "");

            var tienePrograma = await _estudianteRepository.EstudianteYaTieneProgramaAsync(estudianteId);
            if (tienePrograma)
            {
                var programa = await _estudianteRepository.ObtenerProgramaDelEstudianteAsync(estudianteId);
                return (false, "El estudiante ya está adherido a un programa.", programa is null ? "" : programa);
            }


            var nuevaAdhesion = new TbEstudiantePrograma
            {
                EstudianteId = estudianteId,
                ProgramaId = programaId
            };

            await _estudianteRepository.AddProgramaAsync(nuevaAdhesion);
            await _estudianteRepository.SaveChangesAsync();

            return (true, "El estudiante ha sido adherido correctamente al programa.", "");
        }

        public async Task<(bool, string)> ObtenerProgramaDelEstudianteAsync(int estudianteId)
        {
            var programa = await _estudianteRepository.ObtenerProgramaDelEstudianteAsync(estudianteId);
            if(programa is null)
                return (false, "");

            return (true, programa);
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

        public async Task<TbEstudiante> ObtenerEstudiantePorEmailAsync(string email)
        {
            var estidiante = await _estudianteRepository.GetByEmailAsync(email);
            if(estidiante == null)
                throw new Exception("El estudiante no existe.");

            return estidiante;
        }

        public static class CodeGenerator
        {
            private static readonly Random random = new();

            public static string GenerateCode()
            {
                int number = random.Next(1000, 9999);
                return $"A{number}";
            }
        }
    }
}
