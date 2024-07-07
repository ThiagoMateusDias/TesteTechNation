using TesteTechNation.Web;

namespace TesteTechNation.Data.Repository
{
    public class TipoPagamentoRepository : Repository<TipoPagamento>
    {
        public TipoPagamentoRepository(DashBoardFiscaisContext db) : base(db)
        {
        }
    }
}