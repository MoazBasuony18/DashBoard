using DashBoard.DAL.Data;
using DashBoard.Models;

namespace DashBoard.BL
{
    public class CountryRepository : ICountry
    {
        private readonly DbContainer db;

        public CountryRepository(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CountryVM> GetAll()
        {
            var data = db.Countries.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
            return data;
        }

        public CountryVM GetById(int id)
        {
            var data = db.Countries.Where(a => a.Id == id).Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName })
                .FirstOrDefault();
            return data;
        }
    }
}
