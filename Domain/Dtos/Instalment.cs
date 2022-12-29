namespace Domain.Dtos;
using Domain.Entities;

public class GetInstalment
{
    public int CreditId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string ProductName { get; set; }
    public decimal PricePerMonth { get; set; }
    public decimal Period {get; set;}
    public Month Month { get; set; }
    public int ProductId { get; set; }
}