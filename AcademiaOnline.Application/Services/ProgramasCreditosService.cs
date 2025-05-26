using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Services
{

    public class ProgramasCreditosService : IProgramasCreditosService
    {
        private readonly IProgramasCreditosRepository _programasCreditosRepository;

        public ProgramasCreditosService(IProgramasCreditosRepository programasCreditosRepository)
        {
            _programasCreditosRepository = programasCreditosRepository ?? throw new ArgumentNullException(nameof(programasCreditosRepository));
        }
        public async Task<IEnumerable<TbProgramasCredito>> ObtenerTodasAsync()
        {
            return await _programasCreditosRepository.GetAllAsync();
        }

        public async Task<TbProgramasCredito?> ObtenerPorIdAsync(int id)
        {
            var programasCredito = await _programasCreditosRepository.GetByIdAsync(id);
            if (programasCredito == null)
                throw new Exception($"El programa con ID {id} no existe.");

            return programasCredito;
        }
    }

}
