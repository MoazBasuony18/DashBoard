using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public ICollection<District> District { get; set; }
    }
}
