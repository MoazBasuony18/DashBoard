using DashBoard.DAL.Data;
using DashBoard.Models;

namespace DashBoard.BL
{
    public class CityRepository : ICity
    {
        private readonly DbContainer db;

        public CityRepository(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CityVM> GetAll()
        {
            var data = db.Cities.Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId });
            return data;
        }

        public CityVM GetById(int id)
        {
            var data = db.Cities.Where(a => a.Id == id).Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId })
                .SingleOrDefault();
            return data;
        }
    }
}
