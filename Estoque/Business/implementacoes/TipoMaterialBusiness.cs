using Estoque.Business.interfaces;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.implementacoes
{
    public class TipoMaterialBusiness : ITipoMaterialBusiness
    {
        private ITipoMaterialRepository _repository;

        public TipoMaterialBusiness(ITipoMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoMaterial> Create(TipoMaterial obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
             await _repository.Delete(id);
        }

        public async Task<ICollection<TipoMaterial>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<TipoMaterial> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<TipoMaterial> Update(TipoMaterial obj)
        {
            return await _repository.Update(obj);
        }
    }
}
