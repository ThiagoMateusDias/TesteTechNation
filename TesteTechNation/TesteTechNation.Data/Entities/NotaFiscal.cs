namespace TesteTechNation.Web;

public partial class NotaFiscal
{
    public int Id { get; set; }

    public int PagadorId { get; set; }

    public string NumeroIdentificacao { get; set; } = null!;

    public DateOnly DataEmissao { get; set; }

    public DateOnly? DataCobranca { get; set; }

    public DateOnly? DataPagamento { get; set; }

    public decimal Valor { get; set; }

    public string? DocumentoNotaFiscal { get; set; }

    public string? DocumentoBoletoBancario { get; set; }

    public int StatusNotaId { get; set; }

    public int? TipoPagamentoId { get; set; }

    public virtual Pagador Pagador { get; set; } = null!;

    public virtual StatusNotum StatusNota { get; set; } = null!;

    public virtual TipoPagamento? TipoPagamento { get; set; }
}