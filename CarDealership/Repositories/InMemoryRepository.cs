using CarDealership.Entities;
using CarDealership.Interfaces;

namespace CarDealership.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _entities = new();

    public T Add(T entity)
    {
        entity.Id = new Random().Next();
        _entities.Add(entity);
        return entity;
    }

    public IEnumerable<T> Get()
    {
        return _entities;
    }

    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _entities.Where(predicate);
    }
    
    public void Delete(int id)
    {
        var index = _entities.FindIndex(e => e.Id == id);
        if (index == -1) throw new Exception();

        _entities.RemoveAt(index);
    }

    public T? GetById(int id)
    {
        return _entities.FirstOrDefault(entity => entity.Id == id);
    }
}