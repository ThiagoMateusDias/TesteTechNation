using Microsoft.EntityFrameworkCore;
using TesteTechNation;

namespace TesteTechNation.Data.Repository
{
    public class NotaFiscalRepository : Repository<NotaFiscal>
    {
        public NotaFiscalRepository(DashBoardFiscaisContext db) : base(db)
        {
        }

        public override Task<List<NotaFiscal>> ObterTodos()
        {
            return Db.NotaFiscals
             .Include(nf => nf.Pagador)
             .Include(nf => nf.StatusNota)
             .Include(nf => nf.TipoPagamento)
             .ToListAsync();
        }
    }
}