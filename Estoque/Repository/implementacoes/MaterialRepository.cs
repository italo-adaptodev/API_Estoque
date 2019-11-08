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

        public int SaldoMaterial(string descricao)
        {
            //var l = from mat in _context.Material
            //        join ent in _context.EntradaEstoque on mat.Id equals ent.MaterialID
            //        join sai in _context.SaidaEstoque on mat.Id equals sai.MaterialID
            //        where mat.Descricao.Contains(descricao) //and sescricao, "%" + material + "%"))

            //        select new { mat, ent, sai };

            //return l
            //    .Sum(i => i.ent.Quantidade);

            var query = _context.Material.GroupJoin(_context.EntradaEstoque, material => material.Id, entradas => entradas.MaterialID,
                (material, entradas) => new {
                    MaterialID = material.Id,
                    qtdEntradas = entradas.Sum(i => i.Quantidade),
                    descricao = material.Descricao
                }).ToList();

            var qtd = from gp in query
                      join sai in _context.SaidaEstoque on gp.MaterialID equals sai.MaterialID
                      where gp.descricao.Contains(descricao)
                        select new { qtd = gp.qtdEntradas - sai.Quantidade };
            return qtd.Sum(i => i.qtd);
        }
    }
}
      