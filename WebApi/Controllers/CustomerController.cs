using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CustomerController{
    public readonly CustomerService _customerService;
    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetCustomer>>> GetCustomers(){
        return await _customerService.GetCustomer();
    }
    // [HttpGet("GetByPhoneNumber")]
    //  public async Task<Response<GetCustomer>> GetCustomerByPhoneNumber(string phoneNumber){
    //     return await _customerService.GetCustomerByPhoneNumber(phoneNumber);
    // }
    [HttpPost("Add")]
    public async Task<Response<AddCustomer>> InsertCustomer(AddCustomer customer){
        return await _customerService.AddCustomer(customer);
    }
    
    [HttpPut("Update")]
    public async Task<Response<GetCustomer>> Update(AddCustomer customer){
        return await _customerService.Update(customer);
    }
    [HttpDelete("Dalate")]
    public async Task<Customer> Update(int id){
        return await _customerService.Delete(id);
    }
}