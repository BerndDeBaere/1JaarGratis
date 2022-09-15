using AutoMapper;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using EenJaarGratis.Services.Handlers.Responses.Question;

namespace EenJaarGratis.Services.Handlers.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Player, PlayerResponse>();
        CreateMap<UpdatePlayerRequest, Player>().ForMember(x => x.Id, options => options.Ignore());
        
        CreateMap<Question, QuestionResponse>();
    }
}