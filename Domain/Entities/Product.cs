namespace Domain.Entities;
public class Product
{
    public int ProductId { get; set; }
    public ProductType ProductType;
    public string ProductName {get; set;}
    public decimal Price {get; set;}
    public List<Customer> Customers { get; set; }
    public List<Instalment> Instalments { get; set; }
}
public enum ProductType   
{
    Phone = 1,
    Computer,
    TV  
}