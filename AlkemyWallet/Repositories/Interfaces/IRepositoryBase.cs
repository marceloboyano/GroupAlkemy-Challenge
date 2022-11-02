namespace AlkemyWallet.Repositories.Interfaces
{

        public interface IRepositoryBase<T> where T : class
        {
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(int id);
            Task<T> Insert(T entity);
            Task<T>Update(T entity);
            Task Delete(int id);
        }

    
}
