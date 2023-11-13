using AutoMapper;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductRequestDTO>().ReverseMap(); 
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<Category, CategoryRequestDTO>().ReverseMap();
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            CreateMap<Customer, LoginRequestDTO>().ReverseMap();
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
        }
    }
}
