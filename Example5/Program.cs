using AutoMapper;
using System;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            Address empAddres = new Address()
            {
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };

            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Department = "IT",
                address = empAddres
            };
            var mapper = InitializeAutomapper();
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
            Console.WriteLine("City:" + empDTO.addressDTO.EmpCity + ", State:" + empDTO.addressDTO.EmpStae + ", Country:" + empDTO.addressDTO.Country);
            Console.ReadLine();
        }

        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Address, AddressDTO>()
                    .ForMember(dest => dest.EmpCity, act => act.MapFrom(src => src.City))
                    .ForMember(dest => dest.EmpStae, act => act.MapFrom(src => src.State)); ;
                cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.addressDTO, act => act.MapFrom(src => src.address));
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address address { get; set; }
    }
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public AddressDTO addressDTO { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class AddressDTO
    {
        public string EmpCity { get; set; }
        public string EmpStae { get; set; }
        public string Country { get; set; }
    }
}
