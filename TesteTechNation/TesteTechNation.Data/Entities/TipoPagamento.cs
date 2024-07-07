namespace TesteTechNation.Web;

public partial class TipoPagamento
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}