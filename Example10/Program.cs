using AutoMapper;
using System;

namespace Example10
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = InitializeAutomapper();
            Employee employee = new Employee()
            {
                ID = 101,
                Name = "James",
                Address = "Mumbai"
            };
            var empDTO = mapper.Map<Employee, EmployeeDTO>(employee);
            Console.WriteLine("After Mapping : Employee");
            Console.WriteLine("ID : " + employee.ID + ", Name : " + employee.Name + ", Address : " + employee.Address);
            Console.WriteLine();
            Console.WriteLine("After Mapping : EmployeeDTO");
            Console.WriteLine("ID : " + empDTO.ID + ", Name : " + empDTO.Name + ", Address : " + empDTO.Address);
            Console.ReadLine();
        }
        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    //Ignoring the Address property of the destination type
                    .ForMember(dest => dest.Address, act => act.Ignore());
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
