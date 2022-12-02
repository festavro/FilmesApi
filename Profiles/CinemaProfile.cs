using AutoMapper;
using FlimesApi.Data.DTO;
using FlimesApi.Models;

namespace FlimesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
            CreateMap<PutCinemaDTO, Cinema>();
        }
    }
}
