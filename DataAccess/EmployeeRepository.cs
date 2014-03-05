using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class EmployeeRepository
    {
        private readonly SqlConnectionManager sqlConnectionManager;

        public EmployeeRepository(SqlConnectionManager sqlConnectionManager)
        {
            this.sqlConnectionManager = sqlConnectionManager;
        }

        public void Save(Employee employee)
        {
            var sqlConnection = sqlConnectionManager.OpenConnection();

            var query =
                string.Format(
                    "Insert into " +
                    "Employee(EmployeeCode," +
                             "EmployeeName," +
                             "Address," +
                             "PostCode," +
                             "Salary) values ('{0}','{1}','{2}','{3}',{4})",
                             employee.EmployeeCode,
                             employee.EmployeeName,
                             employee.Address,
                             employee.PostCode,
                             employee.Salary);

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnectionManager.ClosConnection();
        }

        public Dictionary<string, string> LoadAllEmployeeNameAndId()
        {
            var sqlConnection = sqlConnectionManager.OpenConnection();

            var employees = new Dictionary<string, string>();
            var query = string.Format("SELECT EMPLOYEEID,EMPLOYEENAME FROM EMPLOYEE");

            var sqlCommand = new SqlCommand(query, sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(reader["EMPLOYEEID"].ToString(),(string)reader["EmployeeName"]);
            }

            sqlConnectionManager.ClosConnection();


            return employees;
        }

        public List<string> LoadAllEmployeeCodes()
        {
            var sqlConnection = sqlConnectionManager.OpenConnection();

            var employeeCodes = new List<string>();
            var query = string.Format("SELECT EMPLOYEECODE FROM EMPLOYEE");

            var sqlCommand = new SqlCommand(query, sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                employeeCodes.Add((string)reader["EmployeeCode"]);
            }

            sqlConnectionManager.ClosConnection();

            return employeeCodes;
        }

        public Employee LoadEmployeeWithId(string employeeId)
        {
            var sqlConnection = sqlConnectionManager.OpenConnection();

            var query = string.Format("SELECT * FROM EMPLOYEE WHERE EMPLOYEEID = " + employeeId);

            var sqlCommand = new SqlCommand(query, sqlConnection);
            var reader = sqlCommand.ExecuteReader();

            var employee = new Employee();

            while (reader.Read())
            {
                employee.EmployeeId = (int)reader["EmployeeId"];
                employee.EmployeeCode = (string)reader["EmployeeCode"];
                employee.EmployeeName = (string)reader["EmployeeName"];
                employee.PostCode = (string)reader["PostCode"];
                employee.Address = (string)reader["Address"];
                employee.Salary = (decimal)reader["Salary"];
            }

            sqlConnectionManager.ClosConnection();

            return employee;
        }

        public void Update(Employee employee)
        {
            var sqlConnection = sqlConnectionManager.OpenConnection();

            var query =
                string.Format(
                    "Update Employee set EmployeeCode = '{0}',EmployeeName = '{1}',Address = '{2}',PostCode = '{3}',Salary = '{4}' where EmployeeId = {5}",
                             employee.EmployeeCode,
                             employee.EmployeeName,
                             employee.Address,
                             employee.PostCode,
                             employee.Salary,
                             employee.EmployeeId);

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnectionManager.ClosConnection();
        }
    }
}
