using TesteTechNation.Web;

namespace TesteTechNation.Business.Interface
{
    public interface INotaFiscalService : IDisposable
    {
        Task<List<NotaFiscal>> ObterPorFiltro(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento);

        Task<List<NotaFiscal>> ObterTodos();

        public Task<List<double>> ObterInadimplentes(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento);

        public Task<List<double>> ObterRecebida(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento);
    }
}