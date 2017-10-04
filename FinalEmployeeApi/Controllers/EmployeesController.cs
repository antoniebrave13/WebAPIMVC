using FinalEmployeeApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalEmployeeApi.Controllers
{
    public class EmployeesController : ApiController
    {
        [Route("api/Employees/GetProducts")]
        [HttpGet]
        public string GetProducts()
        {
            return "GetProducts";
        }
        [Route("api/Employees/Product/{id}")]
        [HttpGet]
        public string Product(string id)
        {
            return id;
        }

        [Route("api/Employees/GetEmployee")]
        [HttpGet]
        public List<Employee> Get()
            {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=192.168.1.151;Database=EmployeeDB;User ID=sa;Password=Admin12345;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Employee";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            List<Employee> empList = new List<Employee>();
            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.id = Convert.ToInt32(reader.GetValue(0));
                emp.Name = reader.GetValue(1).ToString();
                emp.Address = reader.GetValue(2).ToString();
                emp.Age = Convert.ToInt32(reader.GetValue(3));
                emp.Salary = Convert.ToInt32(reader.GetValue(4));
                empList.Add(emp);
            }
            return empList;
            myConnection.Close();
        }

        [Route("api/Employees/AddEmployee/{name}/{address}/{age}/{salary}")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public void AddEmployee(string name, string address, int age, int salary)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  


        SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=192.168.1.151;Database=EmployeeDB;User ID=sa;Password=Admin12345;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "EXEC SAMPLE_PROCEDURE @Name,@Address,@Age,@Salary";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@Name", name);
            sqlCmd.Parameters.AddWithValue("@Address", address);
            sqlCmd.Parameters.AddWithValue("@Age", age);
            sqlCmd.Parameters.AddWithValue("@Salary", salary);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [Route("api/Employees/DeleteEmployee/{id}")]
        [AcceptVerbs("GET", "POST")]
        public void DeleteEmployee(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=192.168.1.151;Database=EmployeeDB;User ID=sa;Password=Admin12345;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Employee where id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [Route("api/Employees/UpdateEmployee/{allowance}/{id}")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public void UpdateEmployee(int allowance, int id)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  


            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=192.168.1.151;Database=EmployeeDB;User ID=sa;Password=Admin12345;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "EXEC SAMPLE_PROCEDURE_ADD @id= @id, @allowance = @Allowance ";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@Allowance", allowance);
            sqlCmd.Parameters.AddWithValue("@id", id);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
