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
    public class EntradaEstoqueRepository : GenericRepository<EntradaEstoque>, IEntradaEstoqueRepository
    {
        public EntradaEstoqueRepository(EstoqueContext context) : base(context) { }

        public async Task<ICollection<EntradaEstoque>> FindByData(int dia, int mes, int ano)
        {
            return await _context.EntradaEstoque
                .Include(p => p.Material)
                .Where(p => p.Data.Day.Equals(dia))
                .Where(p => p.Data.Month.Equals(mes))
                .Where(p => p.Data.Year.Equals(ano))
                .ToListAsync();
        }

        public async Task<ICollection<EntradaEstoque>> FindByMaterial(string material)
        {
            return await _context.EntradaEstoque
                .Include(p => p.Material)
                .Where(p => EF.Functions.Like(p.Material.Descricao, "%" + material + "%"))
                .ToListAsync();
        }

        public int FindQtdByMaterial(string material)
        {
            return  _context.EntradaEstoque
                .Where(p => EF.Functions.Like(p.Material.Descricao, "%" + material + "%"))
                .Sum(i => i.Quantidade);
        }
    }
}
