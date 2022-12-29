namespace Domain.Entities;
public class Instalment
{
    public int InstalmentId { get; set; }
    public decimal PricePerMonth {get; set;}
    public Month Month {get; set;}
    public int CustomerId {get; set;}
    public virtual Customer Customers { get; set; }
    public int ProductId { get; set; }
    public Product Products { get; set; }
}
public enum Month   
{
    month3 = 3,
    month6 = 6,
    month9 = 9,
    month12 = 12,
    month18 = 18,
    month24 = 24   
}
