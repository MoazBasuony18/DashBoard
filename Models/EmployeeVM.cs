using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }

        [Required]
        public float Salary { get; set; }
        public DateTime HireDate { get; set; }

        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string DepartmentId { get; set; }
        public string DistrictId { get; set; }
    }
}
