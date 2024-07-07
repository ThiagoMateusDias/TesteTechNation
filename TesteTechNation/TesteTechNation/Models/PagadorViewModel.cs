namespace TesteTechNation.Web.Models
{
    public class PagadorViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public virtual ICollection<NotaFiscalViewModel> NotaFiscals { get; set; } = new List<NotaFiscalViewModel>();
    }
}