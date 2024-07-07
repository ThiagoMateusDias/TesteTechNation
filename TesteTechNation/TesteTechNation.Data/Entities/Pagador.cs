namespace TesteTechNation.Web;

public partial class Pagador
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}