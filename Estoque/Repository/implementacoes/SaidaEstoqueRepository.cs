using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.implementacoes
{
    public class SaidaEstoqueRepository : GenericRepository<SaidaEstoque>, ISaidaEstoqueRepository
    {
        public SaidaEstoqueRepository(EstoqueContext context) : base(context) { }

        public override async Task<SaidaEstoque> Create(SaidaEstoque item)
        {
            try
            {
                var qtdPresenteNoEstoque = _context.EntradaEstoque.Where(i => i.MaterialID.Equals(item.MaterialID)).Sum(p => p.Quantidade);

                if(item.Quantidade > qtdPresenteNoEstoque)
                    throw new InvalidOperationException("Quantidade retirada excede o numero de itens no estoque!");
                _context.SaidaEstoque.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    int codigoErro = sqlException.Number;
                    if (codigoErro.Equals(2627) || codigoErro.Equals(2601))
                        throw new InvalidOperationException("O recurso já existe!");
                    if (codigoErro.Equals(547))
                        throw new InvalidOperationException("Chave Estrangeira inválida");
                }
                throw ex;
            }
        }

        public async Task<ICollection<SaidaEstoque>> FindByData(DateTime data)
        {
            return await _context.SaidaEstoque
                .Include(p => p.Material)
                .Where(p => p.Data.Date.Equals(data.Date))
                .ToListAsync();
        }

        public async Task<ICollection<SaidaEstoque>> FindByMaterial(string material)
        {
            return await _context.SaidaEstoque
                .Where(p => p.Material.Descricao.Contains(material))
                .ToListAsync();
        }

        public int SaldoSaidaByMaterial(string material)
        {
            return _context.SaidaEstoque
                .Where(i => i.Material.Descricao.Contains(material))
                .Sum(i => i.Quantidade);
        }
    }
}

 