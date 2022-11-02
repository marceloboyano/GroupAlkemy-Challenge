using AlkemyWallet.Repositories.Interfaces;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace AlkemyWallet.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly WalletDbContext dbContext;

        public RepositoryBase(WalletDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        /// <summary>
        /// Esta clase implementa un CRUD básico para cualquier entidad de Entity Framework

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if(entity==null)
            {
                throw new Exception("The entity is null");
            }          
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();    
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            
            var result = await dbContext.Set<T>().FindAsync(id);
            if (result==null)
            {
                throw new Exception("The entity is null");
            }else
            return result;
        }

        public async Task<T> Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
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
    }
}
