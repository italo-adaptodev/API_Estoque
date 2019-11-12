using Estoque.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface ITipoMaterialBusiness
    {
        Task<TipoMaterial> Create(TipoMaterial obj);
        Task<TipoMaterial> Update(TipoMaterial obj);
        Task<TipoMaterial> FindById(int id);
        Task<ICollection<TipoMaterial>> FindAll();
        Task Delete(int id);
    }
}
