using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PayRollSystem.Models
{
    public class Employee
    {
        private const string DECIMAL_WITH_TWO_DECIMAL_PLACES = @"^\d*(\.\d\d?)?$";
        private const string NUMBER = @"^\d{6}$";

        public Field EmployeeId { get; set; }

        [Display(Name = "Employee Code")]
        public Field EmployeeCode { get; set; }

        [Display(Name = "Employee Name")]
        public Field EmployeeName { get; set; }

        [Display(Name = "Address")]
        public Field Address { get; set; }

        [Display(Name = "Post Code")]
        public Field PostCode { get; set; }

        [Display(Name = "Salary")]
        public Field Salary { get; set; }

        public bool Valid()
        {
            var validationResult = true;

            if (string.IsNullOrEmpty(EmployeeCode.Value))
            {
                EmployeeCode.Error = ErrorCodeConstants.EMPLOYEE_CODE_REQUIRED;
                validationResult = false;
            }
            else if (EmployeeCode.Value.Length < 6)
            {
                EmployeeCode.Error = ErrorCodeConstants.INVALID_EMPLOYEE_CODE_LENGTH;
                validationResult = false;
            }
            else if (!(new Regex(NUMBER).IsMatch(EmployeeCode.Value)))
            {
                EmployeeCode.Error = ErrorCodeConstants.INVALID_EMPLOYEE_CODE_FORMAT;
                validationResult = false;
            }

            if (string.IsNullOrEmpty(EmployeeName.Value))
            {
                EmployeeName.Error = ErrorCodeConstants.EMPLOYEE_NAME_IS_REQUIRED;
                validationResult = false;
            }

            else if (!(new Regex(@"^[a-zA-Z ]+$").IsMatch(EmployeeName.Value)))
            {
                EmployeeName.Error = ErrorCodeConstants.INVALID_EMPLOYEE_NAME_FORMAT;
                validationResult = false;
            }

            if (string.IsNullOrEmpty(Address.Value))
            {
                Address.Error = ErrorCodeConstants.ADDRESS_REQUIRED;
                validationResult = false;
            }

            if (string.IsNullOrEmpty(PostCode.Value))
            {
                PostCode.Error = ErrorCodeConstants.POSTCODE_REQUIRED;
                validationResult = false;
            }

            if (string.IsNullOrEmpty(Salary.Value))
            {
                Salary.Error = ErrorCodeConstants.SALARY_REQUIRED;
                validationResult = false;
            }
            else if (!(new Regex(DECIMAL_WITH_TWO_DECIMAL_PLACES).IsMatch(Salary.Value)))
            {
                Salary.Error = ErrorCodeConstants.INVALID_SALARY_FORMAT;
                validationResult = false;
            }
            else if (Convert.ToDecimal(Salary.Value) == 0)
            {
                Salary.Error = ErrorCodeConstants.SALARY_REQUIRED;
                validationResult = false;
            }

            return validationResult;

        }
    }
}
