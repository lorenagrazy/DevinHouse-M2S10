
using FilmeApiCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeApiCodeFirst.Context
{
    public class FilmeContext : DbContext
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
    }
}

