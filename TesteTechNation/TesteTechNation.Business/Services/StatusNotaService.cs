using TesteTechNation.Business.Interface;
using TesteTechNation.Data.Repository;

namespace TesteTechNation.Business.Services
{
    public class StatusNotaService : IStatusNotaService
    {
        private readonly StatusNotaRepository _statusNotaRepository;

        public StatusNotaService(StatusNotaRepository statusNotaRepository) => _statusNotaRepository = statusNotaRepository;

        public virtual Task<List<StatusNotum>> ObterTodos() => _statusNotaRepository.ObterTodos();

        public void Dispose() => _statusNotaRepository?.Dispose();
    }
}