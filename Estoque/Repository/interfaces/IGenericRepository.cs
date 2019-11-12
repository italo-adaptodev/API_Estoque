using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<T> Delete(int id);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
    }
}
