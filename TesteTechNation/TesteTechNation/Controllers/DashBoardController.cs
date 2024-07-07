using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteTechNation.Business.Interface;
using TesteTechNation.Web.Models;

namespace TesteTechNation.Web.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly INotaFiscalService _notaFiscalService;

        private readonly IStatusNotaService _statusNotaService;

        private readonly ITipoPagamentoService _tipoPagamentoService;

        private readonly IMapper _mapper;

        public DashBoardController(INotaFiscalService notaFiscalService, IStatusNotaService statusNotaService, ITipoPagamentoService tipoPagamentoService, IMapper mapper)
        {
            _notaFiscalService = notaFiscalService ?? throw new ArgumentNullException(nameof(notaFiscalService));
            _statusNotaService = statusNotaService ?? throw new ArgumentNullException(nameof(statusNotaService));
            _tipoPagamentoService = tipoPagamentoService ?? throw new ArgumentNullException(nameof(tipoPagamentoService));
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento, int limpar = 0)
        {
            if (limpar == 1)
            {
                tipoPagamentoId = null;
                statusNotaId = null;
                anoPesquisa = null;
                mesPesquisa = null;
                trimestrePesquisa = null;
                mesEmissao = null;
                mesCobranca = null;
                mesPagamento = null;
            }

            int anoAtual = DateTime.Now.Year;
            anoPesquisa ??= anoAtual;

            var notasFiscaisTodas = _mapper.Map<List<NotaFiscalViewModel>>(await _notaFiscalService.ObterTodos());
            var statusNotas = _mapper.Map<List<StatusNotaViewModel>>(await _statusNotaService.ObterTodos());
            var tipoPagamentos = _mapper.Map<List<TipoPagamentoViewModel>>(await _tipoPagamentoService.ObterTodos());
            var notasFiscaisFiltro = _mapper.Map<List<NotaFiscalViewModel>>(await _notaFiscalService.ObterPorFiltro(tipoPagamentoId, statusNotaId, anoPesquisa, mesPesquisa, trimestrePesquisa, mesEmissao, mesCobranca, mesPagamento));

            var tipoPagamentoSelectList = tipoPagamentos.Select(tp => new SelectListItem
            {
                Value = tp.Id.ToString(),
                Text = tp.Descricao
            }).ToList();
            ViewBag.TipoPagamento = new SelectList(tipoPagamentoSelectList, "Value", "Text").OrderBy(o => o.Text).ToList();
            ViewBag.TipoPesquisa = tipoPagamentoId;

            var statusNotaSelectList = statusNotas.Select(st => new SelectListItem
            {
                Value = st.Id.ToString(),
                Text = st.Descricao
            }).ToList();
            ViewBag.StatusNota = new SelectList(statusNotaSelectList, "Value", "Text").OrderBy(o => o.Text).ToList();
            ViewBag.StatusPesquisa = statusNotaId;

            ViewBag.Anos = new SelectList(notasFiscaisTodas.Select(s => s.DataEmissao.Year).Distinct().OrderBy(o => o).ToList()); 
            ViewBag.AnoPesquisa = anoPesquisa.ToString();
            ViewBag.MesPesquisa = mesPesquisa;
            ViewBag.TrimestrePesquisa = trimestrePesquisa;
            ViewBag.MesEmissao = mesEmissao;
            ViewBag.MesCobranca = mesCobranca;
            ViewBag.MesPagamento = mesPagamento;

            ViewBag.TotalNotasGeral = notasFiscaisTodas.Sum(x => x.Valor).ToString("C2");
            ViewBag.TotalNotasAno = notasFiscaisFiltro.Sum(x => x.Valor).ToString("C2");
            ViewBag.NotasSemCobrancaAno = notasFiscaisFiltro.Where(w => w.DataCobranca == null).Sum(x => x.Valor).ToString("C2");
            ViewBag.NotasInadimplenciaAno = notasFiscaisFiltro.Where(w => w.DataPagamento == null && w.DataCobranca < DateOnly.FromDateTime(DateTime.Now)).Sum(x => x.Valor).ToString("C2");
            ViewBag.NotasAVencerAno = notasFiscaisFiltro.Where(w => w.DataPagamento == null && (w.DataCobranca > DateOnly.FromDateTime(DateTime.Now) || w.DataCobranca == null)).Sum(x => x.Valor).ToString("C2");
            ViewBag.NotasPagasAno = notasFiscaisFiltro.Where(w => w.DataPagamento != null).Sum(x => x.Valor).ToString("C2");

            return View(notasFiscaisFiltro);
        }


        public async Task<JsonResult> ObterDadosFinanceiros(int? tipoPagamentoId, int? statusNotaId, int? anoPesquisa, int? mesPesquisa, int? trimestrePesquisa, int? mesEmissao, int? mesCobranca, int? mesPagamento)
        {
            int anoAtual = DateTime.Now.Year;
            anoPesquisa ??= anoAtual;

            var inadimplentesdadosGrafico = await _notaFiscalService.ObterInadimplentes(tipoPagamentoId, statusNotaId, anoPesquisa, mesPesquisa, trimestrePesquisa, mesEmissao, mesCobranca, mesPagamento);

            var recebidaGrafico = await _notaFiscalService.ObterRecebida(tipoPagamentoId, statusNotaId, anoPesquisa, mesPesquisa, trimestrePesquisa, mesEmissao, mesCobranca, mesPagamento);

            var inadimplenciaData = inadimplentesdadosGrafico.ToList();

            var receitaData = recebidaGrafico.ToList();

            var dadosFinanceiros = new DadosFinanceirosViewModel
            {
                Inadimplencia = inadimplenciaData,
                Receita = receitaData
            };

            return Json(dadosFinanceiros);
        }

        protected override void Dispose(bool disposing)
        {
            _notaFiscalService?.Dispose();

            base.Dispose(disposing);
        }
    }
}