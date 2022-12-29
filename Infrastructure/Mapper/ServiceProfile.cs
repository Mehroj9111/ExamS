using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;


public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Customer,GetCustomer>().ReverseMap();
        CreateMap<Customer, AddCustomer>().ReverseMap();
        
        CreateMap<Instalment,GetInstalment>().ReverseMap();

        CreateMap<Product,GetProduct>().ReverseMap();
        CreateMap<Product, AddProduct>().ReverseMap();
        CreateMap<GetProduct, AddProduct>().ReverseMap();

    }
}
