using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmpAt.Models
{
    public class AttendanceDto
    {
        [Required]
        public int EmployeeID { get; set; }
        public DateOnly Date { get; set; }
        [Precision(0)]
        public DateTime CheckInTime { get; set; }
        [Precision(0)]
        public DateTime CheckOutTime { get; set; }
    }
}
