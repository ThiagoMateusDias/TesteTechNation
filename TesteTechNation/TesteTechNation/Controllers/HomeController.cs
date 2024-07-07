using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteTechNation.Business.Interface;
using TesteTechNation.Models;

namespace TesteTechNation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INotaFiscalService _notaFiscalService;

        public HomeController(ILogger<HomeController> logger, INotaFiscalService notaFiscalService)
        {
            _logger = logger;
            _notaFiscalService = notaFiscalService ?? throw new ArgumentNullException(nameof(notaFiscalService));
        }

        public async Task<IActionResult> Index()
        {
            var notasFiscais = await _notaFiscalService.ObterTodos();

            ViewBag.Total = notasFiscais.Sum(x => x.Valor).ToString("C2");
            ViewBag.Quantidade = notasFiscais.Count();
            ViewBag.Pendentes = notasFiscais.Count(x => x.DataPagamento == null);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}