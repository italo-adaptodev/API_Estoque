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

        public override async Task<ICollection<EntradaEstoque>> FindAll()
        {
            return await _context.EntradaEstoque
                .Include(p => p.Material)
                .ToListAsync();
        }

        public override async Task<EntradaEstoque> FindById(int id)
        {
            return await _context.EntradaEstoque
                .Include(p => p.Material)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<ICollection<EntradaEstoque>> FindByData(DateTime data)
        {
            var h = await _context.EntradaEstoque
                .Include(p => p.Material)
                .Where(p => p.Data.Date.Equals(data.Date))
                .ToListAsync();

            return h;
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
