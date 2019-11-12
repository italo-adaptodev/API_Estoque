﻿using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Business.interfaces
{
    public interface IEntradaEstoqueBusiness
    {
        Task<EntradaEstoque> Create(EntradaEstoque obj);
        Task<EntradaEstoque> Update(EntradaEstoque obj);
        Task<EntradaEstoque> FindById(int id);
        Task<ICollection<EntradaEstoque>> FindAll();
        Task Delete(int id);
        Task<ICollection<EntradaEstoque>> FindByData(DateTime data);
        Task<ICollection<EntradaEstoque>> FindByMaterial(string material);
        int FindQtdByMaterial(string material);
    }   
}
