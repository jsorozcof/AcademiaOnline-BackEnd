using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{

    public interface IProgramasCreditosService
    {
        Task<IEnumerable<TbProgramasCredito>> ObtenerTodasAsync();
        Task<TbProgramasCredito?> ObtenerPorIdAsync(int id);
    }
}
