using TesteTechNation.Business.Interface;
using TesteTechNation.Data.Repository;

namespace TesteTechNation.Business.Services
{
    public class TipoPagamentoService : ITipoPagamentoService
    {
        private readonly TipoPagamentoRepository _tipoPagamentoRepository;

        public TipoPagamentoService(TipoPagamentoRepository tipoPagamentoRepository) => _tipoPagamentoRepository = tipoPagamentoRepository;

        public virtual Task<List<TipoPagamento>> ObterTodos() => _tipoPagamentoRepository.ObterTodos();

        public void Dispose() => _tipoPagamentoRepository?.Dispose();
    }
}