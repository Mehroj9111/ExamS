using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ParticipantService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetParticipant>>> GetParticipant()
    {
    try
    {
        var list =_mapper.Map<List<GetParticipant>>(_context.Participants.ToList());
        return new Response<List<GetParticipant>>(list);
    }
 catch (Exception ex)
        {
            return new Response<List<GetParticipant>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddParticipant>> AddParticipant(AddParticipant participant)
    {
    try{
        var newParticipant = _mapper.Map<Participant>(participant);
        _context.Participants.Add(newParticipant);
        await _context.SaveChangesAsync();
        return new Response<AddParticipant>(participant);
    }
     catch (Exception ex)
        {
            return new Response<AddParticipant>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddParticipant>> UpdateParticipant(AddParticipant participant)
    {
    try
    {
        var find = await _context.Participants.FindAsync(participant.Id);
        find.FullName = participant.FullName;
        find.Email = participant.Email;
        find.Phone = participant.Phone;
        find.Password = participant.Password;
        find.CreatedAt = participant.CreatedAt;
        find.GroupId = participant.GroupId;
        find.LocationId = participant.LocationId;
        await _context.SaveChangesAsync();
        return new Response<AddParticipant>(participant);
    }
     catch (Exception ex)
        {
            return new Response<AddParticipant>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DeleteParticipant(int id)
    {
    try
    {
        var find = await _context.Participants.FindAsync(id);
        _context.Participants.Remove(find);
         var result = await _context.SaveChangesAsync();
         if(result > 0)
        return new Response<string>("Participant Successfully Deleted");
        
         return new Response<string>(HttpStatusCode.BadRequest,"Participant not found");
    }
     catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
