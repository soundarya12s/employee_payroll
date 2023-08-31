using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EmployeeManagement
{
    public class EmployeeOperations
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionStr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = EmployeeManagement; integrated security = true";
            con = new SqlConnection(connectionStr);
        }


        public Employee AddEmployee(Employee obj)
        {
            try
            {
                Connection(); // Ensure this method creates and returns a valid SqlConnection object
                using (SqlCommand com = new SqlCommand("AddEmployee", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Name", obj.Name);
                    com.Parameters.AddWithValue("@City", obj.City);
                    com.Parameters.AddWithValue("@Address", obj.Address);

                    con.Open();

                    // Execute the stored procedure and get the result
                    var result = com.ExecuteNonQuery();

                    if (result != null && int.TryParse(result.ToString(), out int empId))
                    {
                        obj.EmpId = empId; // Set the EmpId from the result
                        return obj;
                    }
                    else
                    {
                        throw new Exception("Employee could not be added.");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL-specific exceptions here
                throw new Exception("An SQL error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                throw new Exception("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }




        public Employee AddEmployee(Employee obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@City", obj.City);
                com.Parameters.AddWithValue("@Address", obj.Address);
                con.Open();
                var i = com.ExecuteScalar(); //Executes and returns the num of records added or updated
                obj.EmpId = System.Convert.ToInt32(com.ExecuteScalar());
                if (i != null)
                {
                    obj.EmpId = Convert.ToInt32(i);
                    return obj;
                }
                else
                {
                    return null;
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
        public bool DeleteEmployee(int empId)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", empId);
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
        public void GetAllEmployee()
        {
            Connection();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand com = new SqlCommand("GetAllEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee()
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                    );
            }
            foreach (var data in EmpList)
            {
                Console.WriteLine(data.EmpId + "" + data.Name);
            }
        }
        public bool UpdateEmployee(Employee obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("UpdateEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.EmpId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
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