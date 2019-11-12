using Estoque.Business.interfaces;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.implementacoes
{
    public class SaidaEstoqueBusiness : ISaidaEstoqueBusiness
    {
        private ISaidaEstoqueRepository _repository;

        public SaidaEstoqueBusiness(ISaidaEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<SaidaEstoque> Create(SaidaEstoque obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
             await _repository.Delete(id);
        }

        public async Task<ICollection<SaidaEstoque>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ICollection<SaidaEstoque>> FindByData(DateTime data)
        {
            return await _repository.FindByData(data);
        }

        public async Task<SaidaEstoque> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ICollection<SaidaEstoque>> FindByMaterial(string material)
        {
            return await _repository.FindByMaterial(material);
        }

        public int SaldoSaidaByMaterial(string material)
        {
            return _repository.SaldoSaidaByMaterial(material);
        }

        public async Task<SaidaEstoque> Update(SaidaEstoque obj)
        {
            return await _repository.Update(obj);
        }
    }
}

