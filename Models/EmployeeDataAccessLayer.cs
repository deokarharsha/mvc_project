using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;  
using System.Linq;  
using System.Threading.Tasks; 
  
namespace MVCAdoDemo.Models  
{  
    public class EmployeeDataAccessLayer  
    {  
        string connectionString = "server=.;Database=.;User Id=.;Password=.;";  
  
        //To View all employees details    
        public IEnumerable<Employee> GetAllEmployees()  
        {  
            List<Employee> lstemployee = new List<Employee>();  
  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("crud_getEmployees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                con.Open();  
                SqlDataReader rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    Employee employee = new Employee();  
  
                    employee.ID = Convert.ToInt32(rdr["ID"]);  
                    employee.name = rdr["name"].ToString();  
                    employee.address = rdr["address"].ToString();  
                    employee.department = rdr["department"].ToString();  
                    employee.city = rdr["city"].ToString();  
  
                    lstemployee.Add(employee);  
                }  
                con.Close();  
            }  
            return lstemployee;  
        }  
  
        //To Add new employee record    
        public void AddEmployee(Employee employee)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spCrud_Employees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  

                cmd.Parameters.AddWithValue("@action", "add");
                cmd.Parameters.AddWithValue("@ID", 0);    
                cmd.Parameters.AddWithValue("@name", employee.name);  
                cmd.Parameters.AddWithValue("@address", employee.address);  
                cmd.Parameters.AddWithValue("@department", employee.department);  
                cmd.Parameters.AddWithValue("@city", employee.city);  
                cmd.Parameters.AddWithValue("@basic", DBNull.Value);  
                cmd.Parameters.AddWithValue("@hra",DBNull.Value);  
                cmd.Parameters.AddWithValue("@td", DBNull.Value);  
                cmd.Parameters.AddWithValue("@da", DBNull.Value);  
                cmd.Parameters.AddWithValue("@salary", DBNull.Value);  

                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();   
            }  
        }  
  
        //To Update the records of a particluar employee  
        public void UpdateEmployee(Employee employee)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spCrud_Employees", con);  
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@ID", employee.ID);  
                cmd.Parameters.AddWithValue("@name", employee.name);  
                cmd.Parameters.AddWithValue("@address", employee.address);  
                cmd.Parameters.AddWithValue("@department", employee.department);  
                cmd.Parameters.AddWithValue("@city", employee.city); 
                
                if(employee.basic == 0.0){
                    cmd.Parameters.AddWithValue("@basic", DBNull.Value);  
                 }else{
                     cmd.Parameters.AddWithValue("@basic", employee.basic);  
                }
                
                if(employee.hra == 0.0){
                    cmd.Parameters.AddWithValue("@hra", DBNull.Value);  
                }else{
                    cmd.Parameters.AddWithValue("@hra",employee.hra);  
                }

                if(employee.td == 0.0){
                    cmd.Parameters.AddWithValue("@td", DBNull.Value);  
                }else{
                    cmd.Parameters.AddWithValue("@td", employee.td);
                }

                if(employee.da == 0.0){
                    cmd.Parameters.AddWithValue("@da", DBNull.Value);  
                }else{
                    cmd.Parameters.AddWithValue("@da", employee.td);
                }

                if(employee.salary == 0.0){
                    cmd.Parameters.AddWithValue("@salary", DBNull.Value);  
                }else{
                    cmd.Parameters.AddWithValue("@salary", employee.salary);
                }
  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        //Get the details of a particular employee  
        public Employee GetEmployeeData(int? ID)  
        {    
            Employee employee = new Employee(); 
             
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spCrud_Employees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  

                cmd.Parameters.AddWithValue("@action", "get");
                cmd.Parameters.AddWithValue("@ID", ID);    
                cmd.Parameters.AddWithValue("@name", DBNull.Value);  
                cmd.Parameters.AddWithValue("@address", DBNull.Value);  
                cmd.Parameters.AddWithValue("@department", DBNull.Value);  
                cmd.Parameters.AddWithValue("@city", DBNull.Value);  
                cmd.Parameters.AddWithValue("@basic", DBNull.Value);  
                cmd.Parameters.AddWithValue("@hra",DBNull.Value);  
                cmd.Parameters.AddWithValue("@td", DBNull.Value);  
                cmd.Parameters.AddWithValue("@da", DBNull.Value);  
                cmd.Parameters.AddWithValue("@salary", DBNull.Value);  

                con.Open();  
                // SqlDataReader rdr = cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    employee.ID = Convert.ToInt32(rdr["ID"]);  
                    employee.name = rdr["name"].ToString();  
                    employee.address = rdr["address"].ToString();  
                    employee.department = rdr["department"].ToString();  
                    employee.city = rdr["city"].ToString(); 
                    if(rdr["basic"] == DBNull.Value){
                        employee.basic = 0.0;
                    }else{

                        employee.basic =  Convert.ToInt32(rdr["basic"]);  
                    }

                    if(rdr["hra"] == DBNull.Value){
                         employee.hra = 0.0;
                     }else{

                        employee.hra =  Convert.ToInt32(rdr["hra"]);  
                    }

                    if(rdr["da"] == DBNull.Value){
                        employee.da  = 0.0;
                    }else{
                        employee.da =  Convert.ToInt32(rdr["da"]);
                    }
                    if(rdr["td"] == DBNull.Value){
                        employee.td  = 0.0;
                    }else{
                        employee.td =  Convert.ToInt32(rdr["td"]);
                    }

                    if(rdr["salary"] == DBNull.Value){
                        employee.salary  = 0.0;
                    }else{
                        employee.salary =  Convert.ToInt32(rdr["salary"]);
                    }
                }  
            
                con.Close();  
            } 
            return employee;  
        }  
  
        //To Delete the record on a particular employee  
        public void DeleteEmployee(int? ID)  
        {  
  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spCrud_Employees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                 cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@ID", ID);    
                cmd.Parameters.AddWithValue("@name", DBNull.Value);  
                cmd.Parameters.AddWithValue("@address", DBNull.Value);  
                cmd.Parameters.AddWithValue("@department", DBNull.Value);  
                cmd.Parameters.AddWithValue("@city", DBNull.Value);  
                cmd.Parameters.AddWithValue("@basic", DBNull.Value);  
                cmd.Parameters.AddWithValue("@hra",DBNull.Value);  
                cmd.Parameters.AddWithValue("@td", DBNull.Value);  
                cmd.Parameters.AddWithValue("@da", DBNull.Value);  
                cmd.Parameters.AddWithValue("@salary", DBNull.Value);    
  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
    }  
}  