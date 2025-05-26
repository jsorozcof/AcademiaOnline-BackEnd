using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IMateriasService
    {
        Task<IEnumerable<TbMateria>> ObtenerMateriasProfesoresAsync();
        Task<IEnumerable<TbMateria>> ObtenerTodasAsync();
        Task<TbMateria?> ObtenerPorIdAsync(int id);
    }
}
