using AutoMapper;
using FlimesApi.Data.DTO;
using FlimesApi.Models;

namespace FlimesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<PutFilmeDTO, Filme>();
        }
    }
}
