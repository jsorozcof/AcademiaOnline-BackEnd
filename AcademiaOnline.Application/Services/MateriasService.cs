using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Services
{
    public class MateriasService : IMateriasService
    {
        private readonly IMateriasRepository _materiasRepository;

        public MateriasService(IMateriasRepository materiasRepository)
        {
            _materiasRepository = materiasRepository ?? throw new ArgumentNullException(nameof(materiasRepository));
        }

        // Para Obtener materias que dictan los profesores
        public async Task<IEnumerable<TbMateria>> ObtenerMateriasProfesoresAsync()
        {
            return await _materiasRepository.GetAllMateriasProfesoresAsync();
        }

        // Para Obtener todas las materias
        public async Task<IEnumerable<TbMateria>> ObtenerTodasAsync()
        {
            return await _materiasRepository.GetAllAsync();
        }

        // Para Obtener materia por ID
        public async Task<TbMateria?> ObtenerPorIdAsync(int id)
        {
            var materia = await _materiasRepository.GetByIdAsync(id);
            if (materia == null)
                throw new Exception($"La materia con ID {id} no existe.");

            return materia;
        }

        public async Task<TbMateria> CrearMateriaAsync(TbMateria nuevaMateria)
        {
            if (nuevaMateria == null)
                throw new ArgumentNullException(nameof(nuevaMateria), "La materia no puede ser nula.");

            if (string.IsNullOrWhiteSpace(nuevaMateria.Nombre))
                throw new Exception("El nombre de la materia es obligatorio.");

            if (nuevaMateria.Creditos != 3)
                throw new Exception("Las materias deben tener exactamente 3 créditos.");

            await _materiasRepository.CrearMateriaAsync(nuevaMateria);
            await _materiasRepository.SaveChangesAsync();
            return nuevaMateria;
        }

        // Para Asignar materia a un estudiante
        public async Task<bool> AsignarMateriaAEstudianteAsync(int estudianteId, int materiaId)
        {
            if (await _materiasRepository.EstudianteYaTieneMateriaAsync(estudianteId, materiaId))
                throw new Exception("El estudiante ya tiene esta materia asignada.");

            await _materiasRepository.AsignarMateriaAsync(estudianteId, materiaId);
            await _materiasRepository.SaveChangesAsync();
            return true;
        }

        //Para Validar si un estudiante ya tiene una materia asignada
        public async Task<bool> EstudianteYaTieneMateriaAsync(int estudianteId, int materiaId)
        {
            return await _materiasRepository.EstudianteYaTieneMateriaAsync(estudianteId, materiaId);
        }

        // Para Eliminar materia del estudiante
        public async Task<bool> EliminarMateriaDeEstudianteAsync(int estudianteId, int materiaId)
        {
            if (!await _materiasRepository.EstudianteYaTieneMateriaAsync(estudianteId, materiaId))
                throw new Exception("El estudiante no tiene esta materia asignada.");

            await _materiasRepository.EliminarMateriaAsync(estudianteId, materiaId);
            await _materiasRepository.SaveChangesAsync();
            return true;
        }
    }


}
