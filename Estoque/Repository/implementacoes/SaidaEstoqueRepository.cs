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

        public async Task<ICollection<SaidaEstoque>> FindByData(DateTime data)
        {
            return await _context.SaidaEstoque
                .Include(p => p.Material)
                .Where(p => p.Data.Date.Equals(data.Date))
                .ToListAsync();
        }

        public async Task<ICollection<SaidaEstoque>> FindByMaterial(string material)
        {
            return await _context.SaidaEstoque
                .Where(p => p.Material.Descricao.Contains(material))
                .ToListAsync();
        }

        public int SaldoSaidaByMaterial(string material)
        {
            return _context.SaidaEstoque
                .Where(i => i.Material.Descricao.Contains(material))
                .Sum(i => i.Quantidade);
        }
    }
}

 