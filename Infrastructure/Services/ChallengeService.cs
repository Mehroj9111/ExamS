using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;   

namespace Infrastructure.Services;

public class ChallengeService
{
    private readonly DataContext _contex;
    private readonly IMapper _mappe;

    public ChallengeService(DataContext context, IMapper mapper)
    {
        _contex = context;
        _mappe = mapper;
    }

    public async Task<Response<List<GetChallenge>>> GetChallenge()
    {
    try
    {
        var list =_mappe.Map<List<GetChallenge>>(_contex.Challenges.ToList());
        return new Response<List<GetChallenge>>(list);
    }
     catch (Exception ex)
        {
            return new Response<List<GetChallenge>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddChallenge>> AddChallenge(AddChallenge challenge)
    {
    try
    {
        var newChallenge = _mappe.Map<Challenge>(challenge);
        _contex.Challenges.Add(newChallenge);
        await _contex.SaveChangesAsync();
        return new Response<AddChallenge>(challenge);
    }
     catch (Exception ex)
        {
            return new Response<AddChallenge>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddChallenge>> UpdateChallenge(AddChallenge challenge)
    {
    try
    {
        var find = await _contex.Challenges.FindAsync(challenge.Id);
        find.Title = challenge.Title;
        find.Description = challenge.Description;
        await _contex.SaveChangesAsync();
        return new Response<AddChallenge>(challenge);
    }
     catch (Exception ex)
        {
            return new Response<AddChallenge>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DeleteChallenge(int id)
    {
    try
    {
        var find = await _contex.Challenges.FindAsync(id);
        _contex.Challenges.Remove(find);
        var result = await _contex.SaveChangesAsync();
        if(result > 0)
        return new Response<string>("Challenge Successfully Deleted");
        
         return new Response<string>(HttpStatusCode.BadRequest,"Challenge not found");
    }
     catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
