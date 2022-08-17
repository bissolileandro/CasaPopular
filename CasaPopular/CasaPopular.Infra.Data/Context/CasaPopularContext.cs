using CasaPopular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Infra.Data.Context
{
    public class CasaPopularContext : DbContext
    {
        public CasaPopularContext(string connectionString)
            :base(GetOptions(connectionString))
        {

        }
        public CasaPopularContext(DbContextOptions<CasaPopularContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurarProduto(modelBuilder);

        }
#region [Confiugurartions]
        public void ConfigurarProduto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>(x =>
            {
                x.ToTable("Familia");
                x.HasKey(p => new { p.Id });
                x.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();                
            });

            modelBuilder.Entity<Pontuacao>(x =>
            {
                x.ToTable("Pontuacao");
                x.HasKey(p => new { p.Id });
                x.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                x.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(100);
               
            });
        }
#endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
