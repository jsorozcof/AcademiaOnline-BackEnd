using AcademiaOnline.Domain.Entities;
using AcademiaOnline.Infrastructure.Academia;
using Microsoft.Extensions.Configuration;
using AcademiaOnline.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiaOnline.Infrastructure.Persistence.Repositories
{
    public class ProgramasCreditosRepository : DapperRepository<TbProgramasCredito>, IProgramasCreditosRepository
    {
        private readonly AcademiaOnlineBDContext _context;
        private readonly string _connectionString;

        public ProgramasCreditosRepository(AcademiaOnlineBDContext context, IConfiguration configuration) : base(configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _connectionString = configuration.GetConnectionString("ConexionDatabase")
                                ?? throw new ArgumentNullException("Connection string is missing.");
        }
        public async Task<IEnumerable<TbProgramasCredito>> GetAllAsync()
        {
            return await _context.TbProgramasCreditos.ToListAsync();
        }

        public async Task<TbProgramasCredito?> GetByIdAsync(int id)
        {
            return await _context.TbProgramasCreditos.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task AddAsync(TbProgramasCredito programasCredito)
        {
            try
            {
                await _context.TbProgramasCreditos.AddAsync(programasCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el programas credito a la base de datos.", ex);
            }
        }



        public void Update(TbProgramasCredito programasCredito)
        {
            try
            {
                _context.TbProgramasCreditos.Update(programasCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el programas credito.", ex);
            }
        }

        public void Delete(TbProgramasCredito programasCredito)
        {
            try
            {
                _context.TbProgramasCreditos.Remove(programasCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el programas credito.", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los cambios en la base de datos.", ex);
            }
        }


    }

}
