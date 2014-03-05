using System.Web.Mvc;
using DataAccess;
using PayRollSystem.Mapper;
using PayRollSystem.Models;

namespace PayRollSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly EmployeeMapper employeeMapper;

        public EmployeeController()
            : this(new EmployeeRepository(new SqlConnectionManager()), new EmployeeMapper()) { }

        private EmployeeController(EmployeeRepository employeeRepository, EmployeeMapper employeeMapper)
        {
            this.employeeRepository = employeeRepository;
            this.employeeMapper = employeeMapper;
        }

        public ActionResult RegisterNewEmployee()
        {
            var employees = employeeRepository.LoadAllEmployeeNameAndId();
            var employeeModel = new EmployeeModel
            {
                ExistingEmployees = employees
            };
            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult RegisterNewEmployee(EmployeeModel model, string button)
        {
            if (button == "Cancel") return RedirectToAction("RegisterNewEmployee", "Employee");
            if (model.Employee.Valid() && NoEmployeeExistsWithTheSameCode(model))
            {
                employeeRepository.Save(employeeMapper.MapToDomain(model.Employee));
                return RedirectToAction("RegisterNewEmployee", "Employee");
            }
            model.ExistingEmployees = employeeRepository.LoadAllEmployeeNameAndId();
            return View(model);
        }

        private bool NoEmployeeExistsWithTheSameCode(EmployeeModel model)
        {
            if (employeeRepository.LoadAllEmployeeCodes().Exists(code => code == model.Employee.EmployeeCode.Value))
            {
                model.Employee.EmployeeCode.Error = ErrorCodeConstants.DUPLICATE_EMPLOYEE_CODE;
                return true;
            }
            return false;
        }

        public ActionResult UpdateEmployee(string employeeCode)
        {
            var employee = employeeRepository.LoadEmployeeWithId(employeeCode);

            var model = new EmployeeModel
            {
                Employee = employeeMapper.MapToModel(employee)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeModel model, string button)
        {
            if (button == "Cancel") return RedirectToAction("RegisterNewEmployee", "Employee");
            if (model.Employee.Valid())
            {
                employeeRepository.Update(employeeMapper.MapToDomain(model.Employee));
                return RedirectToAction("RegisterNewEmployee", "Employee");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            return RedirectToAction("RegisterNewEmployee", "Employee");
        }
    }
}
