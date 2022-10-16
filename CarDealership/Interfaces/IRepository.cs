using CarDealership.Entities;

namespace CarDealership.Interfaces;

public interface IRepository<T> where T: IEntity
{
    public T Add(T entity);
    public IEnumerable<T> Get();
    
    public void Delete(int id);
    public T? GetById(int id);
    IEnumerable<T> Find(Func<T, bool> predicate);
}