using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IEntradaEstoqueRepository : IGenericRepository<EntradaEstoque>
    {
        Task<ICollection<EntradaEstoque>> FindByData(int dia, int mes, int ano);
        Task<ICollection<EntradaEstoque>> FindByMaterial(string material);
        int FindQtdByMaterial(string material);
    }
}
