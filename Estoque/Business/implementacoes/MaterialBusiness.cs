using Estoque.Business.interfaces;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.implementacoes
{
    public class MaterialBusiness : IMaterialBusiness
    {
        private IMaterialRepository _repository;

        public MaterialBusiness(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<Material> Create(Material obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Material>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ICollection<Material>> FindMaterialByDescricao(string descricao)
        {
            return await _repository.FindMaterialByDescricao(descricao);
        }

        public async Task<Material> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ICollection<Material>> FindMaterialByTipoMaterial(string tipo)
        {
            return await _repository.FindMaterialByTipoMaterial(tipo);
        }

        public async Task<Material> Update(Material obj)
        {
            return await _repository.Update(obj);
        }
    }
}
