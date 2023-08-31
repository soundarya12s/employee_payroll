using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class Payroll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Start_Date { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public long Basic_pay { get; set; }
        public long Deductions { get; set; }
        public long Taxable_pay { get; set; }
        public long Income_tax { get; set; }
        public long Net_pay { get; set; }
    }
}
