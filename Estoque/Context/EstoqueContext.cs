﻿using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Estoque.Context
{
    public class EstoqueContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<TipoMaterial> TipoMaterial { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<EntradaEstoque> EntradaEstoque { get; set; }
        public DbSet<SaidaEstoque> SaidaEstoque { get; set; }

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
