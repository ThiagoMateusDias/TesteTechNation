namespace TesteTechNation.Web;

public partial class StatusNotum
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}