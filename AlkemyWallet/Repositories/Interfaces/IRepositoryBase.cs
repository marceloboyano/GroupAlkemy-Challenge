namespace AlkemyWallet.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<IQueryable<T>> FindAll();
    Task<IEnumerable<T>> GetAll();
    Task<(int totalPages, IEnumerable<T> recordList)> GetAllPaging(int pageNumber, int pageSize);
    Task<T?> GetById(int id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(int id);
}