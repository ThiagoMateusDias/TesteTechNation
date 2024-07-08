using TesteTechNation.Business.Interface;
using TesteTechNation.Data.Repository;
using TesteTechNation;

namespace TesteTechNation.Business.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly NotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(NotaFiscalRepository notaFiscalRepository) => _notaFiscalRepository = notaFiscalRepository;

        public virtual Task<List<NotaFiscal>> ObterTodos() => _notaFiscalRepository.ObterTodos();

        public async Task<List<NotaFiscal>> ObterPorFiltro(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento)
        {
            var query = await _notaFiscalRepository.ObterTodos();

            if (tipoPagamentoId > 0)
            {
                query = query.Where(nf => nf.TipoPagamentoId == tipoPagamentoId.Value).ToList();
            }

            if (statusNotaId > 0)
            {
                query = query.Where(nf => nf.StatusNotaId == statusNotaId.Value).ToList();
            }

            if (anoPesquisa > 0)
            {
                query = query.Where(nf => nf.DataEmissao.Year == anoPesquisa).ToList();
            }

            if (mesPesquisa > 0)
            {
                query = query.Where(nf => nf.DataEmissao.Month == mesPesquisa || nf.DataCobranca?.Month == mesPesquisa || nf.DataPagamento?.Month == mesPesquisa).ToList();
            }

            if (trimestrePesquisa > 0)
            {
                int[] mesesTrimestre = null;
                switch (trimestrePesquisa)
                {
                    case 1:
                        mesesTrimestre = new int[] { 1, 2, 3 };
                        break;
                    case 2:
                        mesesTrimestre = new int[] { 4, 5, 6 };
                        break;
                    case 3:
                        mesesTrimestre = new int[] { 7, 8, 9 };
                        break;
                    case 4:
                        mesesTrimestre = new int[] { 10, 11, 12 };
                        break;
                }

                query = query.Where(nf => mesesTrimestre.Contains(nf.DataEmissao.Month) || (nf.DataCobranca.HasValue && mesesTrimestre.Contains(nf.DataCobranca.Value.Month)) || (nf.DataPagamento.HasValue && mesesTrimestre.Contains(nf.DataPagamento.Value.Month))).ToList();
            }

            if (mesEmissao > 0)
            {
                query = query.Where(nf => nf.DataEmissao.Month == mesEmissao).ToList();
            }

            if (mesCobranca > 0)
            {
                query = query.Where(nf => nf.DataCobranca.HasValue && nf.DataCobranca.Value.Month == mesCobranca).ToList();
            }

            if (mesPagamento > 0)
            {
                query = query.Where(nf => nf.DataPagamento.HasValue && nf.DataPagamento.Value.Month == mesPagamento).ToList();
            }

            return query.ToList();
        }

        public async Task<List<double>> ObterInadimplentes(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento)
        {
            var query = await ObterPorFiltro(tipoPagamentoId, statusNotaId, anoPesquisa, mesPesquisa, trimestrePesquisa, mesEmissao, mesCobranca, mesPagamento);

            query = query.Where(w => w.DataPagamento == null && w.DataCobranca < DateOnly.FromDateTime(DateTime.Now)).ToList();

            var meses = Enumerable.Range(1, 12);

            var consulta = meses
                .GroupJoin(query,
                    mes => mes,
                    dado => dado.DataCobranca?.Month,
                    (mes, dadosDoMes) => new
                    {
                        Mes = mes,
                        Total = dadosDoMes.Any() ? dadosDoMes.Sum(d => d.Valor) : 0
                    })
                .Select(x => Double.Parse(x.Total.ToString())).ToList();

            return consulta.ToList();
        }

        public async Task<List<double>> ObterRecebida(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento)
        {
            var query = await ObterPorFiltro(tipoPagamentoId, statusNotaId, anoPesquisa, mesPesquisa, trimestrePesquisa, mesEmissao, mesCobranca, mesPagamento);

            query = query.Where(w => w.DataPagamento != null).ToList();

            var meses = Enumerable.Range(1, 12);

            var consulta = meses
                .GroupJoin(query,
                    mes => mes,
                    dado => dado.DataPagamento?.Month,
                    (mes, dadosDoMes) => new
                    {
                        Mes = mes,
                        Total = dadosDoMes.Any() ? dadosDoMes.Sum(d => d.Valor) : 0
                    })
                .Select(x => Double.Parse(x.Total.ToString())).ToList();

            return consulta.ToList();
        }

        public void Dispose() => _notaFiscalRepository?.Dispose();
    }
}