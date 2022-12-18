using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Challenge, AddChallenge>().ReverseMap();
        CreateMap<Challenge, GetChallenge>().ReverseMap();
        CreateMap<GetChallenge, AddChallenge>().ReverseMap();

        CreateMap<Group, AddGroup>().ReverseMap();
        CreateMap<Group, GetGroup>().ReverseMap();
        CreateMap<GetGroup, AddGroup>().ReverseMap();

        CreateMap<Location, AddLocation>().ReverseMap();
        CreateMap<Location, GetLocation>().ReverseMap();
        CreateMap<GetLocation, AddLocation>().ReverseMap();

        CreateMap<Participant, AddParticipant>().ReverseMap();
        CreateMap<Participant, GetParticipant>().ReverseMap();
        CreateMap<GetParticipant, AddParticipant>().ReverseMap();
    }
}
