using AutoMapper;
using System;

namespace Example6
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
            Employee emp = new Employee();
            emp.Name = "James";
            emp.Salary = 20000;
            emp.Department = "IT";
            emp.City = "Mumbai";
            emp.State = "Maharashtra";
            emp.Country = "India";
            var mapper = InitializeAutomapper();
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
            Console.WriteLine("City:" + empDTO.address.City + ", State:" + empDTO.address.State + ", Country:" + empDTO.address.Country);
            Console.ReadLine();
        }

        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.address, act => act.MapFrom(src => new Address() // a bunch of primitives -> complex types
                {
                    City = src.City,
                    State = src.State,
                    Country = src.Country
                }));
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
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address address { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
