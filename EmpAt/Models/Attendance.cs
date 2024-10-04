using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmpAt.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        [Required]
        public int EmployeeID { get; set; } // foregin
        public DateOnly Date { get; set; }
        [Precision(0)]
        public DateTime CheckInTime { get; set; }
        [Precision(0)]
        public DateTime CheckOutTime { get; set;}
        public Employee Employee { get; set; } // depent for foregin key
    }
}
