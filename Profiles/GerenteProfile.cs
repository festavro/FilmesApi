using AutoMapper;
using FlimesApi.Data.DTO;
using FlimesApi.Models;

namespace FlimesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select(c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId})));
            CreateMap<PutGerenteDTO, Gerente>();
        }
    }
}
