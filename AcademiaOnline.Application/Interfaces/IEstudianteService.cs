using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IEstudianteService
    {
        Task<(bool, string, string)> AdherirEstudianteAProgramaAsync(int estudianteId, int programaId);
        Task<(bool, string)> ObtenerProgramaDelEstudianteAsync(int estudianteId);
        Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId);
        Task<List<GetAllEstudiantesDto>> ObtenerEstudiantesAsync();
        Task<TbEstudiante> ObtenerEstudiantePorEmailAsync(string email);
        Task<bool> CrearAlumnoBasicAsync(string nombre, string email);
    }
}
