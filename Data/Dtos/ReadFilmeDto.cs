using ProjetoAlura.Models;

namespace ProjetoAlura.Data.Dtos
{
    public class ReadFilmeDto
    {
        public required string Titulo { get; set; }
        public required string Genero { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
        public ICollection<ReadSessaoDto> ?Sessoes { get; set; }
    }
}