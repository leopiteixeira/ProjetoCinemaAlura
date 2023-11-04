using System.ComponentModel.DataAnnotations;

namespace ProjetoAlura.Models
{
    public class Endereco{

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string ?Logradouro { get; set; }

        [Required(ErrorMessage = "O campo numero é obrigatório")]
        public int numero { get; set; }

        public virtual Cinema ?Cinema { get; set; }
    }
}