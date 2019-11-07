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
    public class TipoMaterialRepository : GenericRepository<TipoMaterial>, ITipoMaterialRepository
    {
        public TipoMaterialRepository(EstoqueContext context) : base(context) { }

    }
}
