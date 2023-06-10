using System.ComponentModel.DataAnnotations;

namespace FilmeApiCodeFirst.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo Nome não pode exceder 200 caracteres")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "O campo Diretor é de preenchimento obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Diretor não pode exceder 100 caracteres")]
        public string Diretor { get; set; }



        [Required(ErrorMessage = "O campo Genero é de preenchimento obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Genero não pode exceder 50 caracteres")]
        public string Genero { get; set; }


        public int Duracao { get; set; }
    }
}
