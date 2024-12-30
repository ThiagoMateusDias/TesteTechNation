namespace TesteTechNation.Data.Repository
{
    public class StatusNotaRepository : Repository<StatusNotum>
    {
        public StatusNotaRepository(DashBoardFiscaisContext db) : base(db)
        {
        }
    }
}