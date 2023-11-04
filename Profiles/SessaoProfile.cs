using AutoMapper;
using ProjetoAlura.Data.Dtos;
using ProjetoAlura.Models;

namespace ProjetoAlura.Profiles
{
    public class SessaoProfile : Profile{
        public SessaoProfile(){
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}