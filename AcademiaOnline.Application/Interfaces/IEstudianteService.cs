using AcademiaOnline.Application.Features.Estudiantes.Dtos;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IEstudianteService
    {
        Task<bool> AdherirEstudianteAProgramaAsync(int estudianteId, int programaId);
        Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId);
        Task<List<GetAllEstudiantesDto>> ObtenerEstudiantesAsync();
        Task<bool> CrearAlumnoBasicAsync(string nombre, string email);
    }
}
