using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
