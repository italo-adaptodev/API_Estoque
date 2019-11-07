using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface ISaidaEstoqueBusiness
    {
        Task<SaidaEstoque> Create(SaidaEstoque obj);
        Task<SaidaEstoque> Update(SaidaEstoque obj);
        Task<SaidaEstoque> FindById(int id);
        Task<ICollection<SaidaEstoque>> FindAll();
        Task Delete(int id);
        Task<ICollection<SaidaEstoque>> FindByData(int dia, int mes, int ano);
        Task<ICollection<SaidaEstoque>> FindByMaterial(string material);
        int FindQtdRetiradaByMaterial(string material);
    }
}
