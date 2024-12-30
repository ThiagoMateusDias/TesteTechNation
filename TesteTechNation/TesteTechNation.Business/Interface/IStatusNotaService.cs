namespace TesteTechNation.Business.Interface
{
    public interface IStatusNotaService : IDisposable
    {
        Task<List<StatusNotum>> ObterTodos();
    }
}