using PlantApp.BLL.DTO;
using System.Collections.Generic;

namespace PlantApp.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T item);
        void Edit(T item);
        void Delete(int id);

        void Dispose();
    }
}