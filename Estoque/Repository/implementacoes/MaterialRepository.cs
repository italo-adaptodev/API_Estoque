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

        public override async Task<ICollection<Material>> FindAll()
        {
            return await _context.Material.Include(material => material.TipoMaterial).ToListAsync();
        }

        public override async Task<Material> FindById(int id)
        {
            return await _context.Material.Include(material => material.TipoMaterial).SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<ICollection<Material>> FindMaterialByDescricao(string descricao)
        {
            return await _context.Material
                .Include(material => material.TipoMaterial)
                .Where(p => EF.Functions.Like(p.Descricao, "%" + descricao + "%"))
                .ToListAsync();

            
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
            var entrada = _context.Material.GroupJoin(_context.EntradaEstoque, material => material.Id, entradas => entradas.MaterialID,
                (material, entradas) => new {
                    MaterialID = material.Id,
                    qtdEntradas = entradas.Sum(i => i.Quantidade),
                    descricao = material.Descricao
                }).ToList();

            var saida = from gp in entrada
                        join sai in _context.SaidaEstoque on gp.MaterialID equals sai.MaterialID 
                        where gp.descricao.Equals(descricao) 
                        select new { qtdSaidas = sai.Quantidade };
            
            int qtdEntrada = entrada.Where(p => p.descricao.Equals(descricao)).Sum(i => i.qtdEntradas);

            return TotalMaterial(qtdEntrada, saida.Sum(i => i.qtdSaidas) );
        }

        private int TotalMaterial(int entrada, int saida)
        {
            return entrada - saida;
        }
    }
}
      