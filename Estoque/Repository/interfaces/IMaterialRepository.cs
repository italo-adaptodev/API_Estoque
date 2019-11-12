using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<ICollection<Material>> FindMaterialByDescricao(string descricao);
        Task<ICollection<Material>> FindMaterialByTipoMaterial(string tipo);
        int SaldoMaterial(string descricao);
    }
}