using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface ISaidaEstoqueRepository : IGenericRepository<SaidaEstoque>
    {
        Task<ICollection<SaidaEstoque>> FindByData(int dia, int mes, int ano);
        Task<ICollection<SaidaEstoque>> FindByMaterial(string material);
        int FindQtdRetiradaByMaterial(string material);

    }
}
