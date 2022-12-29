// using Microsoft.AspNetCore.Mvc;
// using Domain.Entities;
// using Infrastructure.Services;
// using Domain.Dtos;
// using Domain.Wrapper;

// namespace WebApi.Controllers;

// [ApiController]
// [Route("[controller]")]

// public class CreditController{
//     public readonly CreditService _customerService;
//     public CreditController(CreditService customerService)
//     {
//         _customerService = customerService;
//     }

//     [HttpGet("GetAll")]
//     public async Task<Response<List<GetInstalment>>> GetCustomers(){
//         return await _customerService.GetCredits();
//     }
// }



// {
//   "data": [],
//   "message": null,
//   "statusCode": 200
// }