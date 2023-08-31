using System;
namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOperations operations = new EmployeeOperations();
            List<Employee> list = new List<Employee>(); 
            list.Add(new Employee() { Name="a", City="a", Address="a"});
            list.Add(new Employee() { Name = "a", City = "a", Address = "a" });
            list.Add(new Employee() { Name = "b", City = "b", Address = "b" });
            list.Add(new Employee() { Name = "c", City = "c", Address = "c" });
            list.Add(new Employee() { Name = "d", City = "d", Address = "d" });
            list.Add(new Employee() { Name = "e", City = "e", Address = "e" });
            list.Add(new Employee() { Name = "f", City = "f", Address = "f" });

            DateTime start= DateTime.Now;
            foreach(var data in list)
            {
                operations.AddEmployee(data);
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration without thread"+(end-start));

        }
    }
}