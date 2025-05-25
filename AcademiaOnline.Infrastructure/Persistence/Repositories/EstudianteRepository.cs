using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Domain.Entities;
using AcademiaOnline.Infrastructure.Academia;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AcademiaOnline.Infrastructure.Persistence.Repositories
{
    public class EstudianteRepository : DapperRepository<TbEstudiante>, IEstudianteRepository
    {
        private readonly AcademiaOnlineBDContext _context;
        private readonly string _connectionString;

        public EstudianteRepository(AcademiaOnlineBDContext context, IConfiguration configuration) : base(configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _connectionString = configuration.GetConnectionString("ConexionDatabase")
                                ?? throw new ArgumentNullException("Connection string is missing.");
        }

        public async Task AddAsync(TbEstudiante estudiante)
        {
            try
            {
                await _context.TbEstudiantes.AddAsync(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el estudiante a la base de datos.", ex);
            }
        }

        public async Task<TbEstudiante?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.TbEstudiantes
                    .Include(e => e.TbEstudianteMateria)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el estudiante con ID {id}.", ex);
            }
        }

        public void Update(TbEstudiante estudiante)
        {
            try
            {
                _context.TbEstudiantes.Update(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estudiante.", ex);
            }
        }

        public void Delete(TbEstudiante estudiante)
        {
            try
            {
                _context.TbEstudiantes.Remove(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el estudiante.", ex);
            }
        }

        public async Task<bool> TieneClaseConProfesorAsync(int estudianteId, int profesorId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EstudianteId", estudianteId, DbType.Int32);
                parameters.Add("@ProfesorId", profesorId, DbType.Int32);
                

                var result = await GetByIdAsync("fo_ValidarEstudianteProfesor", parameters);

               return result?.Id > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar si el estudiante ya tiene clase con este profesor.", ex);
            }
        }

        public async Task<List<TbMateria>> GetMateriasDisponiblesAsync(int estudianteId)
        {
            try
            {
                var estudiante = await _context.TbEstudiantes
                    .Include(e => e.TbEstudianteMateria)
                    .FirstOrDefaultAsync(e => e.Id == estudianteId);

                var seleccionadas = estudiante?.TbEstudianteMateria.Select(m => m.Id).ToList() ?? new List<int>();

                return await _context.TbMaterias
                    .Where(m => !seleccionadas.Contains(m.Id))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener materias disponibles para el estudiante.", ex);
            }
        }

        public async Task<IEnumerable<TbEstudiante>> GetEstudiantesPorMateriaAsync(int estudianteId, int materiaId)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);

                var parameters = new DynamicParameters();
                parameters.Add("@EstudianteId", estudianteId, DbType.Int32);
                parameters.Add("@MateriaId", materiaId, DbType.Int32);

                var result = await GetAllAsync("fo_ObtenerEstudiantesPorMateria", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los nombres de los compañeros de clase.", ex);
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
