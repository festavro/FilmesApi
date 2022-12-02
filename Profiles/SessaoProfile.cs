using AutoMapper;
using FlimesApi.Data.DTO;
using FlimesApi.Models;

namespace FlimesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
            CreateMap<PutSessaoDTO, Sessao>();
        }
    }
}
