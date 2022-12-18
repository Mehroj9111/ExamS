using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _conte;
    private readonly IMapper _mapp;
    public LocationService(DataContext context, IMapper mapper)
    {
        _conte = context;
        _mapp = mapper;
    }

    public async Task<Response<List<GetLocation>>> GetLocations()
    {
    try
    {
        var list =_mapp.Map<List<GetLocation>>(_conte.Locations.ToList());
        return new Response<List<GetLocation>>(list);
    }
 catch (Exception ex)
        {
            return new Response<List<GetLocation>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddLocation>> AddLocation(AddLocation artist)
    {
    try{
        var newGroup = _mapp.Map<Location>(artist);
        _conte.Locations.Add(newGroup);
        await _conte.SaveChangesAsync();
        return new Response<AddLocation>(artist);
    }
     catch (Exception ex)
        {
            return new Response<AddLocation>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddLocation>> UpdateLocation(AddLocation group)
    {
    try
    {
        var find = await _conte.Locations.FindAsync(group.Id);
        find.Name = group.Name;
        find.Description = group.Description;
        await _conte.SaveChangesAsync();
        return new Response<AddLocation>(group);
    }
     catch (Exception ex)
        {
            return new Response<AddLocation>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DeleteLocation(int id)
    {
    try
    {
        var find = await _conte.Locations.FindAsync(id);
        _conte.Locations.Remove(find);
         var result = await _conte.SaveChangesAsync();
         if(result > 0)
        return new Response<string>("Location Successfully Deleted");
        
         return new Response<string>(HttpStatusCode.BadRequest,"Location not found");
    }
     catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
