namespace Domain.Dtos;
using Domain.Entities;
public class AddProduct
{
     public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}
public class GetProduct
{
    public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
    public decimal PriceCredit {get; set;}
    public decimal Price { get; set; }
}