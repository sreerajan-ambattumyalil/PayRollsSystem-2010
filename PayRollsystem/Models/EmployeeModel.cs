using System.Collections.Generic;

namespace PayRollSystem.Models
{
    public class EmployeeModel
    {
        public Employee Employee { get; set; }

        public Dictionary<string, string> ExistingEmployees { get; set; }
    }
}