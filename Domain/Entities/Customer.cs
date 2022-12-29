namespace Domain.Entities;
public class Customer
{
    public int CustomerId { get; set; }
    public string FullName {get; set;}
    public string PhoneNumber {get; set;}
    public string Address { get; set; }
    public int ProductId { get; set; }
    public Product Products {get; set;}
    public List<Instalment> Instalments {get; set;}
}