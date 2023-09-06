using EmployeePayroll;
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Payroll employee = new Payroll()

            {

                Name = "Soundarya",
                Salary = 30000,
                Start_Date = "07-06-2023",
                Gender = 'F',
                Phone = "1234567890",
                Address = "Chennai",
                Department = "IT",
                Basic_pay = 15000,
                Deductions = 500,
                Taxable_pay = 100,
                Income_tax = 100,
                Net_pay = 1000
            };

            PayrollOperations operations = new PayrollOperations();

            operations.AddEmployee_payroll(employee);

            //operations.DeleteEmployee_payroll(14);

            operations.GetAllEmployee_payroll();

            //Payroll employee1 = new Payroll()

            //{

            //    Id = 4,

            //    Name = "Soundarya",

            //    Salary = 30000,

            //    Start_Date = "07-06-2023",

            //    Gender = 'F',

            //    Phone = "9789286965",

            //    Address = "Chennai",

            //    Department = "IT",

            //    Basic_pay = 15000,

            //    Deductions = 1S00,

            //    Taxable_pay = 100,

            //    Income_tax = 200,

            //    Net_pay = 1000

            //};

            //operations.UpdateEmployee_payroll(employee1);
            //operations.ParticularRange("2023-01-01");
            operations.Calculations();

            List<Payroll> list = new List<Payroll>();
            list.Add(new Payroll()
            {
                Name = "Reji",
                Salary = 50000,
                Start_Date = "01-05-2000",
                Gender = 'M',
                Phone = "1234567890",
                Address = "Kerala",
                Department = "Finance",
                Basic_pay = 20000,
                Deductions = 500,
                Taxable_pay = 100,
                Income_tax = 1000,
                Net_pay = 45000
            });
            list.Add(new Payroll()
            {
                Name = "Jessy",
                Salary = 40000,
                Start_Date = "01-06-2010",
                Gender = 'F',
                Phone = "1234567890",
                Address = "Kerala",
                Department = "Non-Tech",
                Basic_pay = 10000,
                Deductions = 500,
                Taxable_pay = 100,
                Income_tax = 1000,
                Net_pay = 35000
            });
            operations.UsingWithThread(list);
            operations.UsingWithoutThread(list);
        }
    }
}