namespace TesteTechNation.Web.Models
{
    public class StatusNotaViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = null!;

        public virtual ICollection<NotaFiscalViewModel> NotaFiscals { get; set; } = new List<NotaFiscalViewModel>();
    }
}