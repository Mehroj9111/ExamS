using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Participant>()
            .HasOne<Location>(s => s.Locations)
            .WithMany(g => g.Participants)
            .HasForeignKey(s => s.Id);

       modelBuilder.Entity<Participant>()
            .HasOne<Group>(s => s.Groups)
            .WithMany(g => g.Participants)
            .HasForeignKey(s => s.Id);
             
    }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Participant> Participants  { get; set; }
}