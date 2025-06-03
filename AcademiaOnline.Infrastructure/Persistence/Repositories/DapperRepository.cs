using AcademiaOnline.Application.Common.Dto;
using AcademiaOnline.Application.Common.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AcademiaOnline.Infrastructure.Persistence.Repositories
{

    public class DapperRepository<T> : IDapperRepository<T>
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexionDatabase")
                               ?? throw new ArgumentNullException("Connection string is missing.");
        }

        private async Task<bool> ExecuteAsync(string storedProcedure, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                int affectedRows = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return affectedRows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en SQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<ObtenerMateriasPorProfesorDto>> GetAllSubjectsByTeacherAsync(string storedProcedure, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                return await connection.QueryAsync<ObtenerMateriasPorProfesorDto>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los registros: {ex.Message}");
                throw;
            }
        }


        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los registros: {ex.Message}");
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(string storedProcedure, object parameters)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                var result = await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el registro por ID: {ex.Message}");
                throw;
            }
        }



        public async Task<bool> UpsertAsync(string storedProcedure, object parameters) => await ExecuteAsync(storedProcedure, parameters);
        public async Task InsertAsync(string storedProcedure, object parameters) => await ExecuteAsync(storedProcedure, parameters);

        public async Task UpdateAsync(string storedProcedure, object parameters) => await ExecuteAsync(storedProcedure, parameters);

        public async Task DeleteAsync(string storedProcedure, object parameters) => await ExecuteAsync(storedProcedure, parameters);
    }

}
