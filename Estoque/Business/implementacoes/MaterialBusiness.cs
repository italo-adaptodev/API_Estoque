using Estoque.Business.interfaces;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ICollection<Material>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ICollection<Material>> FindByDescricaoMaterial(string descricao)
        {
            return await _repository.FindByDescricaoMaterial(descricao);
        }

        public async Task<Material> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ICollection<Material>> FindByTipoWithDescricao(string tipo)
        {
            return await _repository.FindByTipoWithDescricao(tipo);
        }

        public async Task<Material> Update(Material obj)
        {
            return await _repository.Update(obj);
        }
    }
}
