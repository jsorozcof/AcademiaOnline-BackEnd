using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Common.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<MateriasInscritaDto>> ObtenerMateriasInscritasAsync(int estudianteId);
        Task<int> ObtenerCantidadMateriasInscritasAsync(int estudianteId);
        Task<IEnumerable<EstudianteCompaneroDto>> GetCompanerosDeClaseAsync(int estudianteId);
        Task<bool> AddAsync(string codigo, string nombre, string email);
        Task<bool> SaveSelectedSubjectsAsync(List<int> MateriaIds, int EstudianteId);
        Task<TbEstudiante?> GetByIdAsync(int id);
        Task<TbEstudiante?> GetByEmailAsync(string email);
        void Update(TbEstudiante estudiante);

        void Delete(TbEstudiante estudiante);

        // Verifica si el estudiante ya está inscrito con un profesor
        Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId);

        // Retorna materias disponibles para el estudiante (máximo 3)
        Task<List<TbMateria>> GetMateriasDisponiblesAsync(int estudianteId);

        // Retorna nombres de estudiantes que comparten una clase
        Task<IEnumerable<TbEstudiante>> GetEstudiantesPorMateriaAsync(int estudianteId, int materiaId);
        Task<List<GetAllEstudiantesDto>> ObtenerEstudiantesAsync();
        Task AddProgramaAsync(TbEstudiantePrograma adhesion);
        Task<bool> EstudianteYaTieneProgramaAsync(int estudianteId);
        Task<string?> ObtenerProgramaDelEstudianteAsync(int estudianteId);
        Task SaveChangesAsync();
    }
}
