using AcademiaOnline.Application.Common.Dto;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IMateriasService
    {
        Task<IEnumerable<ObtenerMateriasPorProfesorDto>> ObtenerMateriasPorProfesor();
        Task<IEnumerable<TbMateria>> ObtenerMateriasProfesoresAsync();
        Task<IEnumerable<TbMateria>> ObtenerTodasAsync();
        Task<TbMateria?> ObtenerPorIdAsync(int id);
    }
}
