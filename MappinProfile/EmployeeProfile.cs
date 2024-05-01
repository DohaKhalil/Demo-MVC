using AutoMapper;
using Demo.DaL.Model;
using Demo.DaL.ViweModel;

namespace MVC.Pl.MappinProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeVM, Employee>().ReverseMap();

        }
    }
}
