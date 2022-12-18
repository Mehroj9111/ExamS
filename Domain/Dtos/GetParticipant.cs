namespace Domain.Dtos;

public class GetParticipant
{
       public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string GroupId { get; set; }
    public string LocationId { get; set; }
}
