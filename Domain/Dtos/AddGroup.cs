namespace Domain.Dtos;

public class AddGroup
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeededMember { get; set; }
    public int TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}
