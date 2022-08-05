using AutoMapper;
using System;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step1: Create and populate the Employee object
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
            Console.WriteLine("City:" + empDTO.address.City + ", State:" + empDTO.address.State + ", Country:" + empDTO.address.Country);
            Console.ReadLine();
        }

        // not correct such mapping
        //static Mapper InitializeAutomapper()
        //{
        //    var config = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<Employee, EmployeeDTO>();
        //    });
        //    var mapper = new Mapper(config);
        //    return mapper;
        //}

        // correct
        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Address, AddressDTO>();
                cfg.CreateMap<Employee, EmployeeDTO>();
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
        public AddressDTO address { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class AddressDTO
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
