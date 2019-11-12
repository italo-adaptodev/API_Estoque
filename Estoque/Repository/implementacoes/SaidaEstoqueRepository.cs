using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.implementacoes
{
    public class SaidaEstoqueRepository : GenericRepository<SaidaEstoque>, ISaidaEstoqueRepository
    {
        public SaidaEstoqueRepository(EstoqueContext context) : base(context) { }

        public async Task<ICollection<SaidaEstoque>> FindByData(int dia, int mes, int ano)
        {
            return await _context.SaidaEstoque
                .Where(p => p.Data.Day.Equals(dia))
                .Where(p => p.Data.Month.Equals(mes))
                .Where(p => p.Data.Year.Equals(ano))
                .ToListAsync();
        }

        public async Task<ICollection<SaidaEstoque>> FindByMaterial(string material)
        {
            return await _context.SaidaEstoque
                .Where(p => p.Material.Descricao.Contains(material))
                .ToListAsync();
        }

        public int FindQtdRetiradaByMaterial(string material)
        {
            return _context.SaidaEstoque
                .Where(p => EF.Functions.Like(p.Material.Descricao, "%" + material + "%"))
                .Sum(i => i.Quantidade);
        }


    }
}

 