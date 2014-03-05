namespace PayRollSystem.Models
{
    public class ErrorCodeConstants
    {
        public const string INVALID_EMPLOYEE_NAME_FORMAT = "The employee name should contain only alphabets";
        public const string EMPLOYEE_CODE_REQUIRED = "The employee code is required";
        public const string INVALID_EMPLOYEE_CODE_LENGTH = "The employee code should have a length of 6";
        public const string INVALID_EMPLOYEE_CODE_FORMAT = "The employee code should contain numbers only";
        public const string EMPLOYEE_NAME_IS_REQUIRED = "The employee name is required";
        public const string ADDRESS_REQUIRED = "The address is required";
        public const string POSTCODE_REQUIRED = "The post code is required";
        public const string SALARY_REQUIRED = "The salary is required";
        public const string INVALID_SALARY_FORMAT = "The salary field can have a maximum of 15 digits followed by 2 decimal places";
        public const string DUPLICATE_EMPLOYEE_CODE = "An employee with the same code already exists";
    }
}