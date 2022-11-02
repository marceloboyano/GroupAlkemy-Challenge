using AlkemyWallet.Repositories.Interfaces;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace AlkemyWallet.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly WalletDbContext dbContext;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> entities;
        public RepositoryBase(WalletDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }
        /// <summary>
        /// Esta clase implementa un CRUD básico para cualquier entidad de Entity Framework
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public async Task<T> GetById(int id)
        {

            var result = await entities.FindAsync(id);
            if (result == null)
            {
                throw new Exception("The entity is null");
            }
            else
                return result;
        }
        public async Task<T> Insert(T entity)
        {
            entities.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {

            var currentState = dbContext.Entry(entity).State;
            if (currentState == EntityState.Unchanged)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }

            return entity;

        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if(entity==null)
            {
                throw new Exception("The entity is null");
            }
            entities.Remove(entity);
                await dbContext.SaveChangesAsync();    
            
        }
        
    }
}
