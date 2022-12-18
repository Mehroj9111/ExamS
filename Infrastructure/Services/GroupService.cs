using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public GroupService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetGroup>>> GetGroup()
    {
    try
    {
        var list =_mapper.Map<List<GetGroup>>(_context.Groups.ToList());
        return new Response<List<GetGroup>>(list);
    }
 catch (Exception ex)
        {
            return new Response<List<GetGroup>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddGroup>> AddGroup(AddGroup artist)
    {
    try{
        var newGroup = _mapper.Map<Group>(artist);
        _context.Groups.Add(newGroup);
        await _context.SaveChangesAsync();
        return new Response<AddGroup>(artist);
    }
     catch (Exception ex)
        {
            return new Response<AddGroup>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddGroup>> UpdateGroup(AddGroup group)
    {
    try
    {
        var find = await _context.Groups.FindAsync(group.Id);
        find.GroupNick = group.GroupNick;
        find.ChallengeId = group.ChallengeId;
        find.NeededMember = group.NeededMember;
        find.TeamSlogan = group.TeamSlogan;
        find.CreatedAt = group.CreatedAt;
        await _context.SaveChangesAsync();
        return new Response<AddGroup>(group);
    }
     catch (Exception ex)
        {
            return new Response<AddGroup>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DeleteGroup(int id)
    {
    try
    {
        var find = await _context.Groups.FindAsync(id);
        _context.Groups.Remove(find);
         var result = await _context.SaveChangesAsync();
         if(result > 0)
        return new Response<string>("Group Successfully Deleted");
        
         return new Response<string>(HttpStatusCode.BadRequest,"Group not found");
    }
     catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
