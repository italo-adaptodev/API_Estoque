using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface IEntradaEstoqueBusiness
    {
        Task<EntradaEstoque> Create(EntradaEstoque obj);
        Task<EntradaEstoque> Update(EntradaEstoque obj);
        Task<EntradaEstoque> FindById(int id);
        Task<ICollection<EntradaEstoque>> FindAll();
        Task<bool> Delete(int id);
        Task<ICollection<EntradaEstoque>> FindByData(int dia, int mes, int ano);
        Task<ICollection<EntradaEstoque>> FindByMaterialID(int id);
    }
}
