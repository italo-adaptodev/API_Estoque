using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface ITipoMaterialBusiness
    {
        Task<TipoMaterial> Create(TipoMaterial obj);
        Task<TipoMaterial> Update(TipoMaterial obj);
        Task<TipoMaterial> FindById(int id);
        Task<ICollection<TipoMaterial>> FindAll();
        Task<bool> Delete(int id);
    }
}
