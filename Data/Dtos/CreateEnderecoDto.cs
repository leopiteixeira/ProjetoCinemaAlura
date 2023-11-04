using System.ComponentModel.DataAnnotations;

namespace ProjetoAlura.Data.Dtos
{
    public class CreateEnderecoDto{

        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string ?Logradouro { get; set; }

        [Required(ErrorMessage = "O campo numero é obrigatório")]
        public int numero { get; set; }
    }
}