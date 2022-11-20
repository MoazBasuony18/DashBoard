namespace DashBoard.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> City { get; set; }
    }
}
