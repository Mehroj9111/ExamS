using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Wrapper;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    
    public async Task<Response<List<GetProduct>>> GetProducts( Month month )
    {
        var products = await _context.Products.ToListAsync();
        var list = new List<GetProduct>();
        foreach (var t in products)
        {
            var newProduct = new GetProduct()
            {
                ProductId = t.ProductId,
                ProductType = t.ProductType,
                ProductName = t.ProductName,
                Price = GetPrice(t.ProductType, t.Price, month ),
                PriceCredit = GetCredits(t.ProductType, t.Price, month )
            };
            list.Add(newProduct);
        }
       return new Response<List<GetProduct>>(list);
    }

    public async Task<Response<AddProduct>> AddProduct(AddProduct product)
    {
                var newTodo = new Product()
                {
                    ProductType = product.ProductType,
                    ProductName = product.ProductName,
                    Price = product.Price,
                
                };  
            _context.Products.Add(newTodo);
             await _context.SaveChangesAsync();
            return new Response<AddProduct>(product);
    }
    
    public async Task<Response<AddProduct>> Update(AddProduct product)
    {
        
        var find = await _context.Products.FindAsync(product.ProductId);
        find.ProductType = product.ProductType;
        find.ProductName =  product.ProductName;
        find.Price = product.Price;
        await _context.SaveChangesAsync();
        return new Response<AddProduct>(product);
    }
    
    public async Task<Product> Delete(int id)
    {
        var todo = await _context.Products.FindAsync(id);
        _context.Products.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
    public decimal GetCredits(   ProductType productType, decimal price, Month month )
    {
        if ( Month.month9 >= month && ProductType.Phone == productType ){
            return price / ((decimal)month);
        }
        if ( Month.month12 <= month && Month.month18 >= month && ProductType.Phone == productType ){
            return (price + (price * 3 / 100)) / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.Phone == productType ){
            return (price + (price * 6 / 100)) / ((decimal)month);
        }
        //------
        if ( Month.month12 >= month && ProductType.Computer == productType ){
            return price / ((decimal)month);
        }
        if ( Month.month18 >= month && ProductType.Computer == productType ){
            return (price + (price * 4 / 100)) / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.Computer == productType ){
            return (price + (price * 8 / 100)) / ((decimal)month);
        }
        //-------
         if ( Month.month18 >= month && ProductType.TV == productType ){
            return price / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.TV == productType ){
            return (price + (price * 5 / 100)) / ((decimal)month);
        }
        return price;
    }
     public decimal GetPrice(   ProductType productType, decimal price, Month month )
    {
        if ( Month.month9 >= month && ProductType.Phone == productType ){
            return price ;
        }
        if ( Month.month12 <= month && Month.month18 >= month && ProductType.Phone == productType ){
            return (price + (price * 3 / 100)) ;
        }
        if ( Month.month24 >= month && ProductType.Phone == productType ){
            return (price + (price * 6 / 100)) ;
        }
        //------
        if ( Month.month12 >= month && ProductType.Computer == productType ){
            return price;
        }
        if ( Month.month18 >= month && ProductType.Computer == productType ){
            return (price + (price * 4 / 100)) ;
        }
        if ( Month.month24 >= month && ProductType.Computer == productType ){
            return (price + (price * 8 / 100));
        }
        //-------
         if ( Month.month18 >= month && ProductType.TV == productType ){
            return price;
        }
        if ( Month.month24 >= month && ProductType.TV == productType ){
            return (price + (price * 5 / 100)) ;
        }
        return price;
    }
}
