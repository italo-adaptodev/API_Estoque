using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface IMaterialBusiness
    {
        Task<Material> Create(Material obj);
        Task<Material> Update(Material obj);
        Task<Material> FindById(int id);
        Task<ICollection<Material>> FindAll();
        Task<bool> Delete(int id);
        Task<ICollection<Material>> FindByDescricaoMaterial(string descricao);
        Task<ICollection<Material>> FindByTipoWithDescricao(string tipo);
    }
}
