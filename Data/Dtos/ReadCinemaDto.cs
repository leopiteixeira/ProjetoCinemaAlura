using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoAlura.Models;

namespace ProjetoAlura.Data.Dtos
{
    public class ReadCinemaDto{
        
        public string ?Id { get; set; }
        public string ?Nome { get; set; }
        public ReadEnderecoDto ?Endereco { get; set; }
        public ICollection<ReadSessaoDto> ?Sessoes { get; set; }
    }
}