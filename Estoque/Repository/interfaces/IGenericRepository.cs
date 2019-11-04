using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<bool> Delete(int id);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
    }
}
