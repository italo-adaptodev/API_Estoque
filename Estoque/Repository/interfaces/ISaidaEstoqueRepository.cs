using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface ISaidaEstoqueRepository : IGenericRepository<SaidaEstoque>
    {
        Task<ICollection<SaidaEstoque>> FindByData(DateTime data);
        Task<ICollection<SaidaEstoque>> FindByMaterial(string material);
        int FindQtdRetiradaByMaterial(string material);
    }
}
