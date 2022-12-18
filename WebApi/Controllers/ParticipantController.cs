using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;


namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]


public class ParticipantController
{
    private readonly ParticipantService _participantService;
    public ParticipantController(ParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet("GetParticipant")]
    public async Task<Response<List<GetParticipant>>> GetParticipant()
    {
        return await _participantService.GetParticipant();
    }

    [HttpPost("InserParticipant")]
    public async Task<Response<AddParticipant>> AddLocation(AddParticipant participant)
    {
        return await _participantService.AddParticipant(participant);
    }

    [HttpPut("UpdateParticipant")]
    public async Task<Response<AddParticipant>> UpdateLocation(AddParticipant participant)
    {
        return await _participantService.UpdateParticipant(participant);
    }

    [HttpDelete("DeleteParticipant")]
    public async Task<Response<string>> DeleteTrack(int id)
    {
        return await _participantService.DeleteParticipant(id);
    }
}
