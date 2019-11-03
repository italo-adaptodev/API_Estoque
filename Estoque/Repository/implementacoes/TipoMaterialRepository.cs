using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Repository.implementacoes
{
    public class TipoMaterialRepository : GenericRepository<TipoMaterial>, ITipoMaterialRepository
    {
        public TipoMaterialRepository(EstoqueContext context) : base(context) { }

        public override async Task<TipoMaterial> Create(TipoMaterial item)
        {
            _context.TipoMaterial.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public override async Task<bool> Delete(int id)
        {
            var resultado = await _context.TipoMaterial.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    return false;
                _context.TipoMaterial.Remove(resultado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<ICollection<TipoMaterial>> FindAll()
        {
            return await _context.TipoMaterial.ToListAsync();
        }

        public override async Task<TipoMaterial> FindById(int id)
        {
            return await _context.TipoMaterial.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public override async Task<TipoMaterial> Update(TipoMaterial item)
        {
            var resultado = await _context.TipoMaterial.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
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
    }
}
