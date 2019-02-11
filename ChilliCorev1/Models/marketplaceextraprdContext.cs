using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChilliCorev1.Models
{
    public partial class marketplaceextraprdContext : DbContext
    {
        public marketplaceextraprdContext()
        {
        }

        public marketplaceextraprdContext(DbContextOptions<marketplaceextraprdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaProdutos> CategoriaProdutos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<ChaveValor> ChaveValor { get; set; }
        public virtual DbSet<Especificacao> Especificacao { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=core-askme-dev.database.windows.net;Initial Catalog=marketplace-extra-prd;User Id=sql;Password=cwi@2018;MultipleActiveResultSets=True;;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaProdutos>(entity =>
            {
                entity.HasIndex(e => e.CategoriaId);

                entity.HasIndex(e => e.ProdutoId);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.CategoriaProdutos)
                    .HasForeignKey(d => d.CategoriaId);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.CategoriaProdutos)
                    .HasForeignKey(d => d.ProdutoId);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasIndex(e => e.CategoriaId);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.InverseCategoria)
                    .HasForeignKey(d => d.CategoriaId);
            });

            modelBuilder.Entity<ChaveValor>(entity =>
            {
                entity.HasIndex(e => e.EspecificacaoId);

                entity.HasOne(d => d.Especificacao)
                    .WithMany(p => p.ChaveValor)
                    .HasForeignKey(d => d.EspecificacaoId);
            });

            modelBuilder.Entity<Especificacao>(entity =>
            {
                entity.HasIndex(e => e.ProdutoId);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Especificacao)
                    .HasForeignKey(d => d.ProdutoId);
            });

            modelBuilder.Entity<Imagem>(entity =>
            {
                entity.HasIndex(e => e.ProdutoId);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Imagem)
                    .HasForeignKey(d => d.ProdutoId);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasIndex(e => e.CategoriaPrincipalId);

                entity.HasOne(d => d.CategoriaPrincipal)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.CategoriaPrincipalId);
            });
        }
    }
}
