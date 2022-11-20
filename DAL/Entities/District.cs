using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
