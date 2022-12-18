namespace Domain.Entities;
public class Participant
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string GroupId { get; set; }
    public Group Groups { get; set; }
    public string LocationId { get; set; }
    public Location Locations { get; set; }
}