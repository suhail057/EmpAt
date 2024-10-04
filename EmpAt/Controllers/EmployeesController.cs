using EmpAt.Models;
using EmpAt.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpAt.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            Employee emp = new Employee()
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Department = employeeDto.Department,
            };

            _context.Employees.Add(emp);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            var empdto = new EmployeeDto()
            {
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
            };

            ViewData["EmployeeID"] = employee.EmployeeID;

            return View(empdto);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeDto employeeDto)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            if (!ModelState.IsValid)
            {
                ViewData["EmployeeID"] = employee.EmployeeID;
                return View(employeeDto);
            }

            //updating the database
            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Department = employeeDto.Department;

            _context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}
