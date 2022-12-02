using AutoMapper;
using FlimesApi.Data.DTO;
using FlimesApi.Models;

namespace FlimesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<PutEnderecoDTO, Endereco>();
        }
    }
}
