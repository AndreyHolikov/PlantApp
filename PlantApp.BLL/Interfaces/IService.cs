using System.Collections.Generic;

namespace PlantApp.BLL.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T item);
        void Edit(T item);
        void Delete(int id);

        void Dispose();
    }
}