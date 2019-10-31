using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.implementacoes
{
    public class TipoMaterialRepository : GenericRepository<TipoMaterial>, ITipoMaterial
    {
        public TipoMaterialRepository(EstoqueContext context) : base(context) { }

        public override async Task<TipoMaterial> Create(TipoMaterial item)
        {
            _context.TipoMaterial.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
