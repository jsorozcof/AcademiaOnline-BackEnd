using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IEstudianteService
    {
        Task<List<MateriasInscritaDto>> ObtenerMateriasInscritasAsync(int estudianteId);
        Task<IEnumerable<EstudianteCompaneroDto>> GetCompanerosDeClaseAsync(int estudianteId);
        Task<bool> SaveSelectedSubjectsAsync(List<int> MateriaIds, int EstudianteId);
        Task<(bool, string, string)> AdherirEstudianteAProgramaAsync(int estudianteId, int programaId);
        Task<(bool, string)> ObtenerProgramaDelEstudianteAsync(int estudianteId);
        Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId);
        Task<List<GetAllEstudiantesDto>> ObtenerEstudiantesAsync();
        Task<TbEstudiante> ObtenerEstudiantePorEmailAsync(string email);
        Task<(bool, string)> CrearAlumnoBasicAsync(string nombre, string email);
    }
}
