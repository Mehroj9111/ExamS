using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class CustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CustomerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // --GetCustomer--
    public async Task<Response<List<GetCustomer>>> GetCustomer()
    {

//-------------------------------------------------------------------+
    //     var customers = await _context.Customers.ToListAsync();   +
    //     var list = new List<GetCustomer>();                       + 
    //                                                               + 
    //     foreach (var c in customers)                              +
    //     {                                                         + 
    //         var customer = new GetCustomer()                      +
    //         {                                                     +
    //             CustomerId = c.CustomerId,                        +
    //             FullName = c.FullName,                            +
    //             PhoneNumber = c.PhoneNumber,                      +
    //             Address = c.Address                               +
    //         };                                                    +
    //         list.Add(customer);                                   +
    //     }                                                         +
    //     return new Response<List<GetCustomer>>(list);             +
    // }                                                             +
// ------------------------------------------------------------------+

      var list = (
            from c in _context.Customers
            join p in _context.Products on c.ProductId equals p.ProductId
            select new GetCustomer()
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                ProductId = p.ProductId
            }
      ).ToList();
      return new Response<List<GetCustomer>>(list);
    }
    
//  --  vaz only returns one number  --

    // public async Task<Response<GetCustomer>> GetCustomerByPhoneNumber(string phoneNumber)
    // {
    //     var customer = await _context.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    //     return new Response<GetCustomer>(_mapper.Map<GetCustomer>(customer));
    // }

   public async Task<Response<AddCustomer>> AddCustomer(AddCustomer  customer)
   {
    var newCustomer = new Customer()
    {
        FullName = customer.FullName,
        PhoneNumber = customer.PhoneNumber,
        Address = customer.Address,
        ProductId = customer.ProductId
    };
    _context.Customers.Add(newCustomer);
    await _context.SaveChangesAsync();
    return new Response<AddCustomer>( _mapper.Map<AddCustomer>(newCustomer));
    }
    public async Task<Response<GetCustomer>> Update(AddCustomer customer)
    {
        
        var find = await _context.Customers.FindAsync(customer.CustomerId);
        find.FullName = customer.FullName;
        find.PhoneNumber = customer.PhoneNumber;
        await _context.SaveChangesAsync();
        return new Response<GetCustomer>(_mapper.Map<GetCustomer>(find));
    }
    public async Task<Customer> Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
}