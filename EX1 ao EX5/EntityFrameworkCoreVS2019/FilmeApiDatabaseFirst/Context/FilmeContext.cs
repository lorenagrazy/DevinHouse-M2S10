using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FilmeApiDatabaseFirst.Models;

#nullable disable

namespace FilmeApiDatabaseFirst.Context
{
    public partial class FilmeContext : DbContext
    {
        public FilmeContext()
        {
        }

        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.Property(e => e.Diretor)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
