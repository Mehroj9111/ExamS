using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("Controller")]



public class GroupController
{
    private readonly GroupService _groupService;
    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("GetGroup")]
    public async Task<Response<List<GetGroup>>> GetGroup()
    {
        return await _groupService.GetGroup();
    }

    [HttpPost("AddGroup")]
    public async Task<Response<AddGroup>> AddGroup(AddGroup group)
    {
        return await _groupService.AddGroup(group);
    }

    [HttpPut("UpdateGroup")]
    public async Task<Response<AddGroup>> UpdateArtist(AddGroup group)
    {
        return await _groupService.UpdateGroup(group);
    }

    [HttpDelete("DeleteGroup")]
    public async Task<Response<string>> DeleteGroup(int id)
    {
        return await _groupService.DeleteGroup(id);
    }
}
