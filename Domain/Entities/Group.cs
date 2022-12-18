namespace Domain.Entities;
public class Group
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public Challenge Challenges ;
    public bool NeededMember { get; set; }
    public int TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Participant> Participants { get; set; }
    
}