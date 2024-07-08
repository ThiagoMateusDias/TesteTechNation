using TesteTechNation;

namespace TesteTechNation.Data.Repository
{
    public class TipoPagamentoRepository : Repository<TipoPagamento>
    {
        public TipoPagamentoRepository(DashBoardFiscaisContext db) : base(db)
        {
        }
    }
}