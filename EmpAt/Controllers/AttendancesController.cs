using EmpAt.Models;
using EmpAt.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpAt.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly AppDbContext _context;
        public AttendancesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var attendances = _context.Attendances.ToList();
            return View(attendances);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AttendanceDto attendanceDto)
        {
            if (!ModelState.IsValid)
            {
                return View(attendanceDto);
            }

            Attendance attendance = new Attendance()
            {
                EmployeeID = attendanceDto.EmployeeID,
                Date = attendanceDto.Date,
                CheckInTime = attendanceDto.CheckInTime,
                CheckOutTime = attendanceDto.CheckOutTime,
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return RedirectToAction("Index", "Attendances");
        }

        public IActionResult Edit(int id)
        {
            var attendance = _context.Attendances.Find(id);

            if (attendance == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            var attendanceDto = new AttendanceDto()
            {
                EmployeeID = attendance.EmployeeID,
                Date = attendance.Date,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
            };

            ViewData["AttendanceID"] = attendance.AttendanceID;

            return View(attendanceDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, AttendanceDto attendanceDto)
        {
            var attendance = _context.Attendances.Find(id);

            if (attendance == null)
            {
                return RedirectToAction("Index", "Attendances");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AttendanceID"] = attendance.AttendanceID;
                return View(attendanceDto);
            }

            attendance.EmployeeID = attendanceDto.EmployeeID;
            attendance.Date = attendanceDto.Date;
            attendance.CheckInTime = attendanceDto.CheckInTime;
            attendance.CheckOutTime = attendanceDto.CheckOutTime;

            _context.SaveChanges();
            return RedirectToAction("Index", "Attendances");
        }

        public IActionResult Delete(int id)
        {
            var attendance = _context.Attendances.Find(id);
            if (attendance == null)
            {
                return RedirectToAction("Index", "Attendances");
            }

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return RedirectToAction("Index", "Attendances");
        }
    }
}
