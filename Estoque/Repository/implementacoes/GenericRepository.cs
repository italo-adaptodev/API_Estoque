using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly EstoqueContext _context;
        protected DbSet<T> dataset;

        public GenericRepository(EstoqueContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public virtual async Task<T> Create(T item)
        {
            try
            {
                dataset.Add(item);
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
                        throw new InvalidOperationException("Chave Estrangeira inválida! ");
                }
                throw ex;
            }
        }

        public async Task<T> Delete(int id)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    throw new Exception("O recurso não foi encontrado para exclusão");

                _context.Entry(resultado).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<ICollection<T>> FindAll()
        {
            return await dataset.ToListAsync();
        }

        public virtual async Task<T> FindById(int id)
        {
            return await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public virtual async Task<T> Update(T item)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
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
