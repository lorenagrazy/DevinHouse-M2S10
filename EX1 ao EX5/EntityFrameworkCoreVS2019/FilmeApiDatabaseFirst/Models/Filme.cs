using System;
using System.Collections.Generic;

#nullable disable

namespace FilmeApiDatabaseFirst.Models
{
    public partial class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
    }
}
