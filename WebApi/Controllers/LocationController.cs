using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]


public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("GetLocation")]
    public async Task<Response<List<GetLocation>>> GetLocation()
    {
        return await _locationService.GetLocations();
    }

    [HttpPost("AddLocation")]
    public async Task<Response<AddLocation>> AddLocation(AddLocation track)
    {
        return await _locationService.AddLocation(track);
    }

    [HttpPut("UpdateLocation")]
    public async Task<Response<AddLocation>> UpdateLocation(AddLocation track)
    {
        return await _locationService.UpdateLocation(track);
    }

    [HttpDelete("DeleteLocation")]
    public async Task<Response<string>> DeleteTrack(int id)
    {
        return await _locationService.DeleteLocation(id);
    }
}
