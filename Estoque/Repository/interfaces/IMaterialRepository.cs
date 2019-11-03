using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<ICollection<Material>> FindByDescricaoMaterial(string descricao);
        Task<ICollection<Material>> FindByTipoWithDescricao(string tipo);
    }
}
