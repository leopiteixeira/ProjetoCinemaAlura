using AutoMapper;
using ProjetoAlura.Models;
using ProjetoAlura.Data.Dtos;

namespace ProjetoAlura.Profiles
{
    public class EnderecoProfile : Profile{

        public EnderecoProfile(){
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}