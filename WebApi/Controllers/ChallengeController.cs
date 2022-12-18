namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

[ApiController]
[Route("Controller")]


public class ChalengeController
{
    private readonly ChallengeService _challengeService;

    public ChalengeController(ChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet("GetChallenge")]
    public async Task<Response<List<GetChallenge>>> GetAlbums()
    {
        return await _challengeService.GetChallenge();
    }

    [HttpPost("AddChallenge")]
    public async Task<Response<AddChallenge>> AddAlbum(AddChallenge challenge)
    {
        return await _challengeService.AddChallenge(challenge);
    }

    [HttpPut("updateChallenge")]
    public async Task<Response<AddChallenge>> UpdateAlbum(AddChallenge challenge)
    {
        return await _challengeService.UpdateChallenge(challenge);
    }

    [HttpDelete("DeleteChallenge")]
    public async Task<Response<string>> DeleteAllbum(int id)
    {
        return await _challengeService.DeleteChallenge(id);
    }
}
