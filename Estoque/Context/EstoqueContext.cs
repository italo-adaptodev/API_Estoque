using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Context
{
    public class EstoqueContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<TipoMaterial> TipoMaterial { get; set; }
        

        public EstoqueContext() { }

        public EstoqueContext(DbContextOptions<EstoqueContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
