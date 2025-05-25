namespace AcademiaOnline.Application.Common.Interfaces
{
    public interface IDapperRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure, object parameters);
        Task<T?> GetByIdAsync(string storedProcedure, object parameters);
        Task<bool> UpsertAsync(string storedProcedure, object parameters);
        Task UpdateAsync(string storedProcedure, object parameters);
        Task DeleteAsync(string storedProcedure, object parameters);

    }
}
