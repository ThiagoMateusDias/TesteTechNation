using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TesteTechNation.Data.Interface;

namespace TesteTechNation.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DashBoardFiscaisContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DashBoardFiscaisContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entidade com ID {id} não encontrada.");
            }

            return entity;
        }

        public virtual async Task<List<TEntity>> ObterTodos() => await DbSet.ToListAsync();

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);

            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            var entity = await ObterPorId(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }
        }

        public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}