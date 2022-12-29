// using Domain.Entities;
// using Domain.Dtos;
// using AutoMapper;
// using Infrastructure.Context;
// using Microsoft.EntityFrameworkCore;
// using System.Net;
// using Domain.Wrapper;

// namespace Infrastructure.Services;


// public class CreditService
// {
//     private readonly DataContext _context;
//     private readonly IMapper _mapper;


//     public CreditService(DataContext context)
//     {
//         _context = context;
//     }
    
//     public async Task<Response<List<GetInstalment>>> GetCredits()
//     {
//         var credits = await _context.Instalments.ToListAsync();
//         var list = new List<GetInstalment>();
        
//         foreach (var data in credits)
//         {
//             var findC = _context.Customers.FirstOrDefault(x=>x.CustomerId == data.CustomerId);
//             var findP = _context.Products.FirstOrDefault(x=>x.ProductId == data.ProductId);
//             var customer = new GetInstalment()
//             {
//                 CreditId = data.CustomerId,
//                 FullName = findC.FullName,
//                 PhoneNumber = findC.PhoneNumber,
//                 Address = findC.Address,
//                  ProductName = findP.ProductName,
//                 PricePerMonth = data.PricePerMonth,
//                 Month = data.Month
//             };
//             list.Add(customer);
//         }
//        return new Response<List<GetInstalment>>(list);
//     }
// }