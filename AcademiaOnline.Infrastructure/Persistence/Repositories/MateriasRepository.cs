using AcademiaOnline.Application.Common.Dto;
using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Domain.Entities;
using AcademiaOnline.Infrastructure.Academia;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AcademiaOnline.Infrastructure.Persistence.Repositories
{

    public class MateriasRepository : DapperRepository<TbEstudiante>, IMateriasRepository 
    {
        private readonly AcademiaOnlineBDContext _context;

        private readonly string _connectionString;

        public MateriasRepository(AcademiaOnlineBDContext context, IConfiguration configuration) : base(configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _connectionString = configuration.GetConnectionString("ConexionDatabase")
                                ?? throw new ArgumentNullException("Connection string is missing.");
        }


        // Para traer materias y profesores
        public async Task<IEnumerable<ObtenerMateriasPorProfesorDto>> ObtenerMateriasPorProfesor()
        {
            try
            {
                var parameters = new DynamicParameters();
                var result = await GetAllSubjectsByTeacherAsync("fo_ObtenerMateriasPorProfesor", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar si el estudiante ya tiene clase con este profesor.", ex);
            }
        }
        public async Task<IEnumerable<TbMateria>> GetAllMateriasProfesoresAsync()
        {
            return await _context.TbMaterias.Include(x => x.TbProfesorMateria).ToListAsync();
        }
        public async Task<IEnumerable<TbMateria>> GetAllAsync()
        {
            return await _context.TbMaterias.ToListAsync();
        }

        public async Task<TbMateria?> GetByIdAsync(int id)
        {
            return await _context.TbMaterias.FirstOrDefaultAsync(m => m.Id == id);
        }

        // Para Asignar materia a un estudiante
        public async Task AsignarMateriaAsync(int estudianteId, int materiaId)
        {
            var nuevaRelacion = new TbEstudianteMateria
            {
                EstudianteId = estudianteId,
                MateriaId = materiaId
            };

            await _context.TbEstudianteMateria.AddAsync(nuevaRelacion);
        }

        // Para Validar si un estudiante ya tiene la materia
        public async Task<bool> EstudianteYaTieneMateriaAsync(int estudianteId, int materiaId)
        {
            return await _context.TbEstudianteMateria
                .AnyAsync(em => em.EstudianteId == estudianteId && em.MateriaId == materiaId);
        }

        public async Task EliminarMateriaAsync(int estudianteId, int materiaId)
        {
            var materiaAsignada = await _context.TbEstudianteMateria
                .FirstOrDefaultAsync(em => em.EstudianteId == estudianteId && em.MateriaId == materiaId);

            if (materiaAsignada != null)
            {
                _context.TbEstudianteMateria.Remove(materiaAsignada);
            }
        }

        public async Task<TbMateria> CrearMateriaAsync(TbMateria nuevaMateria)
        {
            await _context.TbMaterias.AddAsync(nuevaMateria);
            return nuevaMateria;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
