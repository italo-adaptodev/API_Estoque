using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.implementacoes
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(EstoqueContext context) : base(context) { }

        public async Task<ICollection<Material>> FindMaterialByDescricao(string descricao)
        {
            var yes = await _context.Material
                .Include(material => material.TipoMaterial)
                .Where(p => EF.Functions.Like(p.Descricao, "%" + descricao + "%"))
                .ToListAsync();

            return yes;
        }

        public async Task<ICollection<Material>> FindMaterialByTipoMaterial(string tipo)
        {
            return await _context.Material
                .Include(material => material.TipoMaterial)
                .Where(p => p.TipoMaterial.tipo.Equals(tipo))
                .ToListAsync();
        }

        //public int SaldoMaterial(string descricao)
        //{
        //    var v = from m in _context.Set<Material>()
        //            join e in _context.Set<EntradaEstoque>()
        //                on m.Id equals e.MaterialID 
        //                from s in  
                        
        //            from s in _context.Set<SaidaEstoque>().Where(s => m.Id == s.MaterialID).DefaultIfEmpty
        //            select new { m, e, s };


        //}

    }
}
