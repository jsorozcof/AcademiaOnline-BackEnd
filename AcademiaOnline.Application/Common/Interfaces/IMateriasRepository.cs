using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Common.Interfaces
{
    public interface IMateriasRepository
    {
        Task<IEnumerable<TbMateria>> GetAllAsync();
        Task<IEnumerable<TbMateria>> GetAllMateriasProfesoresAsync();
        Task<TbMateria?> GetByIdAsync(int id);

        // Asignar una materia a un estudiante
        Task AsignarMateriaAsync(int estudianteId, int materiaId);

        // Validar si un estudiante ya tiene una materia asignada
        Task<bool> EstudianteYaTieneMateriaAsync(int estudianteId, int materiaId);

        // Eliminar una materia de un estudiante
        Task EliminarMateriaAsync(int estudianteId, int materiaId);
        Task<TbMateria> CrearMateriaAsync(TbMateria nuevaMateria);

        Task SaveChangesAsync();
    }
}
