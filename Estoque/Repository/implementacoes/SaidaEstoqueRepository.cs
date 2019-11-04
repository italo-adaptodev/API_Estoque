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

        public override async Task<SaidaEstoque> Create(SaidaEstoque item)
        {
            _context.SaidaEstoque.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public override async Task<bool> Delete(int id)
        {
            var resultado = await _context.SaidaEstoque.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    return false;
                _context.SaidaEstoque.Remove(resultado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<ICollection<SaidaEstoque>> FindAll()
        {
            return await _context.SaidaEstoque.ToListAsync();
        }

        public override async Task<SaidaEstoque> FindById(int id)
        {
            return await _context.SaidaEstoque.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public override async Task<SaidaEstoque> Update(SaidaEstoque item)
        {
            var resultado = await _context.SaidaEstoque.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
            try
            {
                if (resultado == null)
                    throw new Exception("O item não existe");
                _context.Entry(resultado).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<SaidaEstoque>> FindByData(int dia, int mes, int ano)
        {
            return await _context.SaidaEstoque
                .Where(p => p.Data.Day.Equals(dia))
                .Where(p => p.Data.Month.Equals(mes))
                .Where(p => p.Data.Year.Equals(ano))
                .ToListAsync();
        }

        public async Task<ICollection<SaidaEstoque>> FindByMaterialID(int id)
        {
            return await _context.SaidaEstoque
                .Where(p => p.MaterialID.Equals(id))
                .ToListAsync();
        }
    }
}

 