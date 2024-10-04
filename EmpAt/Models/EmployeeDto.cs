using System.ComponentModel.DataAnnotations;

namespace EmpAt.Models
{
    public class EmployeeDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Department { get; set; }
    }
}
