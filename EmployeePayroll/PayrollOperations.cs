using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class PayrollOperations
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionStr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = payroll_service; integrated security = true";
            con = new SqlConnection(connectionStr);
        }
        public bool AddEmployee_payroll(Payroll obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddEmployee_payroll", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", obj.Name);
                com.Parameters.AddWithValue("@salary", obj.Salary);
                com.Parameters.AddWithValue("@start_Date", obj.Start_Date);
                com.Parameters.AddWithValue("@gender", obj.Gender);
                com.Parameters.AddWithValue("@phone", obj.Phone);
                com.Parameters.AddWithValue("@address", obj.Address);
                com.Parameters.AddWithValue("@department", obj.Department);
                com.Parameters.AddWithValue("@basic_pay", obj.Basic_pay);
                com.Parameters.AddWithValue("@deductions", obj.Deductions);
                com.Parameters.AddWithValue("@taxable_pay", obj.Taxable_pay);
                com.Parameters.AddWithValue("@income_tax", obj.Income_tax);
                com.Parameters.AddWithValue("@net_pay", obj.Net_pay);
                con.Open();
                int i = com.ExecuteNonQuery(); //Executes and returns the num of records added or updated
                con.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteEmployee_payroll(int Id)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeleteEmployee_payroll", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllEmployee_payroll()
        {
            Connection();
            List<Payroll> List = new List<Payroll>();
            SqlCommand com = new SqlCommand("GetAllEmployee_payroll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                List.Add(
                    new Payroll()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["name"]),
                        Salary = Convert.ToInt32(dr["salary"]),
                        Start_Date = Convert.ToString(dr["start_date"]),
                        Gender = Convert.ToChar(dr["gender"]),
                        Phone = Convert.ToString(dr["phone"]),
                        Address = Convert.ToString(dr["address"]),
                        Department = Convert.ToString(dr["department"]),
                        Basic_pay = Convert.ToInt32(dr["basic_pay"]),
                        Deductions = Convert.ToInt32(dr["deductions"]),
                        Taxable_pay = Convert.ToInt32(dr["taxable_pay"]),
                        Income_tax = Convert.ToInt32(dr["income_tax"]),
                        Net_pay = Convert.ToInt32(dr["net_pay"]),
                    }
                    );
            }
            foreach (var data in List)
            {
                Console.WriteLine(data.Id + " " + data.Name + data.Salary + " " + data.Start_Date + data.Gender + " " + data.Phone
                    + data.Address + " " + data.Department + data.Basic_pay + " " + data.Deductions + data.Taxable_pay
                    + " " + data.Income_tax + " " + data.Net_pay);
            }
        }
        public bool UpdateEmployee_payroll(Payroll obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("UpdateEmployee_payroll", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@name", obj.Name);
            com.Parameters.AddWithValue("@salary", obj.Salary);
            com.Parameters.AddWithValue("@start_date", obj.Start_Date);
            com.Parameters.AddWithValue("@gender", obj.Gender);
            com.Parameters.AddWithValue("@phone", obj.Phone);
            com.Parameters.AddWithValue("@address", obj.Address);
            com.Parameters.AddWithValue("@department", obj.Department);
            com.Parameters.AddWithValue("@basic_pay", obj.Basic_pay);
            com.Parameters.AddWithValue("@deductions", obj.Deductions);
            com.Parameters.AddWithValue("@taxable_pay", obj.Taxable_pay);
            com.Parameters.AddWithValue("@income_tax", obj.Income_tax);
            com.Parameters.AddWithValue("@net_pay", obj.Net_pay);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
