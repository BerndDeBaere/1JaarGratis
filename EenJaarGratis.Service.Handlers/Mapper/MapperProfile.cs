using AutoMapper;
using EenJaarGratis.Service.Storage.Domain;

namespace EenJaarGratis.Service.Handlers.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Player, Responses.PlayerResponse>();
    }
}