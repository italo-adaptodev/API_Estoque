using Estoque.Business.interfaces;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.implementacoes
{
    public class EntradaEstoqueBusiness : IEntradaEstoqueBusiness
    {
        private IEntradaEstoqueRepository _repository;

        public EntradaEstoqueBusiness(IEntradaEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntradaEstoque> Create(EntradaEstoque obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
             await _repository.Delete(id);
        }

        public async Task<ICollection<EntradaEstoque>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ICollection<EntradaEstoque>> FindByData(int dia, int mes, int ano)
        {
            return await _repository.FindByData(dia, mes, ano);
        }

        public async Task<EntradaEstoque> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ICollection<EntradaEstoque>> FindByMaterial(string material)
        {
            return await _repository.FindByMaterial(material);
        }

        public int FindQtdByMaterial(string material)
        {
            return _repository.FindQtdByMaterial(material);
        }

        public async Task<EntradaEstoque> Update(EntradaEstoque obj)
        {
            return await _repository.Update(obj);
        }
    }
}
