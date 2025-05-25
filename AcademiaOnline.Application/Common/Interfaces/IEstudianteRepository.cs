using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Common.Interfaces
{
    public interface IEstudianteRepository
    {
        Task AddAsync(TbEstudiante estudiante);

        Task<TbEstudiante?> GetByIdAsync(int id);

        void Update(TbEstudiante estudiante);

        void Delete(TbEstudiante estudiante);

        // Verifica si el estudiante ya está inscrito con un profesor
        Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId);

        // Retorna materias disponibles para el estudiante (máximo 3)
        Task<List<TbMateria>> GetMateriasDisponiblesAsync(int estudianteId);

        // Retorna nombres de estudiantes que comparten una clase
        Task<IEnumerable<TbEstudiante>> GetEstudiantesPorMateriaAsync(int estudianteId, int materiaId);


        Task SaveChangesAsync();
    }
}
