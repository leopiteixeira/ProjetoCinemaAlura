using System.ComponentModel.DataAnnotations;

namespace ProjetoAlura.Data.Dtos
{
    public class CreateSessaoDto{

        [Required]
        public int FilmeId { get; set; }

        [Required]
        public int CinemaId { get; set; }
    }
}