using System.ComponentModel.DataAnnotations;

namespace ProjetoAlura.Data.Dtos
{
    public class CreateFilmeDto{

        [Required(ErrorMessage = "O título é um campo obrigatório!")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero é um campo obrigatório!")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do genero é de 50 caracteres!")]
        public required string Genero { get; set; }

        [Required(ErrorMessage = "A duração é um campo obrigatório!")]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos!")]
        public int Duracao { get; set; }
    }
}