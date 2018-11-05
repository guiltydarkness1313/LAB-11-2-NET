using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CRUD_LAB11.Models;

namespace CRUD_LAB11.Repository
{
    public class EmpRepository
    {
        private SqlConnection connection;

        private void connectionDB()
        {
            string cons = ConfigurationManager.ConnectionStrings["tecsup"].ToString();
            connection = new SqlConnection(cons);
        }
        public bool AddEmployee(Employee obj)
        {
            connectionDB();
            SqlCommand command = new SqlCommand("AddNewEmployeeDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", obj.name);
            command.Parameters.AddWithValue("@address", obj.address);
            command.Parameters.AddWithValue("@city", obj.city);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //lista de datos de los empleados
        public List<Employee> GetEmployees()
        {
            connectionDB();
            List<Employee> employees = new List<Employee>();
            SqlCommand command = new SqlCommand("GetEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach(DataRow data in dataTable.Rows)
            {
                employees.Add(new Employee
                    {
                    id = Convert.ToInt32(data["id"]),
                    name = Convert.ToString(data["name"]),
                    city = Convert.ToString(data["city"]),
                    address = Convert.ToString(data["address"])
                });
            }

            return employees;
        }

        public bool UpdateEmployee(Employee obj)
        {
            connectionDB();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@city", obj.city);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@id", obj.id);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int  id)
        {
            connectionDB();
            SqlCommand com = new SqlCommand("DeleteEmpById", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
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