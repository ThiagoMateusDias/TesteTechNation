namespace TesteTechNation.Models
{
    public class TipoPagamentoViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = null!;

        public virtual ICollection<NotaFiscalViewModel> NotaFiscals { get; set; } = new List<NotaFiscalViewModel>();
    }
}