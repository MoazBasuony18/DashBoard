namespace DashBoard.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
