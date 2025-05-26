using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Common.Interfaces
{
    public interface IProgramasCreditosRepository
    {
        Task<IEnumerable<TbProgramasCredito>> GetAllAsync();
        Task<TbProgramasCredito?> GetByIdAsync(int id);
        Task AddAsync(TbProgramasCredito programasCredito);
        void Update(TbProgramasCredito programasCredito);
        void Delete(TbProgramasCredito programasCredito);
        Task SaveChangesAsync();
    }
}
