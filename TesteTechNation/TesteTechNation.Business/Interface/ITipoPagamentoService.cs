using TesteTechNation;

namespace TesteTechNation.Business.Interface
{
    public interface ITipoPagamentoService : IDisposable
    {
        Task<List<TipoPagamento>> ObterTodos();
    }
}