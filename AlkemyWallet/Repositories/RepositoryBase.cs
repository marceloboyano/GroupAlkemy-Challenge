using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

<<<<<<< HEAD
        private readonly WalletDbContext dbContext;
        protected readonly DbSet<T> entities;
        public RepositoryBase(WalletDbContext dbContext)
=======
        private readonly WalletDbContext _context;
        private Microsoft.EntityFrameworkCore.DbSet<T> _entities;
        public RepositoryBase(WalletDbContext context)
>>>>>>> dev
        {
            _context = context;
            _entities = context.Set<T>();
        }
        /// <summary>
        /// Esta clase implementa un CRUD básico para cualquier entidad de Entity Framework
        public async Task<IEnumerable<T>> GetAll()
        {
<<<<<<< HEAD
            return await Task.FromResult(entities.AsEnumerable());
=======
            return await Task.FromResult(_entities.AsEnumerable());
>>>>>>> dev
        }
        public async Task<T> GetById(int id)
        {

            var result = await _entities.FindAsync(id);
          
                return result;
        }
        public async Task Insert(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            
        }
        public async Task<bool> Update(T entity)
        {

            _context.Update(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;

        }
        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);


            if (entity != null)
            {

                _entities.Remove(entity);
                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0;
            }
            return false;
    }
    }
}
