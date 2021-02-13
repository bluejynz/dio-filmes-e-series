using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T returnById(int id);
         void Insert(T entity);
         void Remove(int id);
         void Update(int id, T entity);
         int NextId();
    }
}