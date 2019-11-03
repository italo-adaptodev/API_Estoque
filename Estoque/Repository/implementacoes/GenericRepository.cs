using Estoque.Context;
using Estoque.Models;
using Estoque.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            dataset.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    return false;
                dataset.Remove(resultado);
                await _context.SaveChangesAsync();
                return true;
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
