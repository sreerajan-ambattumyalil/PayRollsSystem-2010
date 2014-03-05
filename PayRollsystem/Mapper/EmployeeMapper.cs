using System;
using System.Globalization;
using PayRollSystem.Models;

namespace PayRollSystem.Mapper
{
    public class EmployeeMapper
    {
        public Employee MapToModel(DataAccess.Employee employee)
        {
            return new Employee
            {
                EmployeeId = new Field(employee.EmployeeId.ToString()),
                EmployeeCode = new Field(employee.EmployeeCode),
                EmployeeName = new Field(employee.EmployeeName),
                PostCode = new Field(employee.PostCode),
                Address = new Field(employee.Address),
                Salary = new Field(employee.Salary.ToString(CultureInfo.InvariantCulture)),
            };
        }

        public DataAccess.Employee MapToDomain(Employee employee)
        {
            return new DataAccess.Employee
            {
                EmployeeId = employee.EmployeeId.Value == null ? 0 : Convert.ToInt32(employee.EmployeeId.Value),
                EmployeeCode = employee.EmployeeCode.Value,
                EmployeeName = employee.EmployeeName.Value,
                PostCode = employee.PostCode.Value,
                Address = employee.Address.Value,
                Salary = Convert.ToDecimal(employee.Salary.Value)
            };
        }
    }
}