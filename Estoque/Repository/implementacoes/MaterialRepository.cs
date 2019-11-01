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
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(EstoqueContext context) : base(context) { }

        public override async Task<Material> Create(Material item)
        {
            _context.Material.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public override async Task<bool> Delete(int id)
        {
            var resultado = await _context.Material.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    return false;
                _context.Material.Remove(resultado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<ICollection<Material>> FindAll()
        {
            return await _context.Material.ToListAsync();
        }

        public override async Task<Material> FindById(int id)
        {
            return await _context.Material.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public override async Task<Material> Update(Material item)
        {
            var resultado = await _context.Material.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
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

        public async Task<ICollection<Material>> FindByDescricaoMaterial(string descricao)
        {
            return await _context.Material
                .Where(p => p.Descricao.Equals(descricao))
                .ToListAsync();
        }

        public async Task<ICollection<Material>> FindByTipoWithDescricao(string tipo)
        {
            return await _context.Material
                .Where(p => p.TipoMaterialID.Descricao.Equals(tipo))
                .ToListAsync();
        }
    }
}
