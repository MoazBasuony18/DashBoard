using DashBoard.DAL.Data;
using DashBoard.Models;

namespace DashBoard.BL
{
    public class DistrictRepository : IDistrict
    {
        private readonly DbContainer db;

        public DistrictRepository(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<DistrictVM> GetAll()
        {
            var data = db.Districts.Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId });
            return data;
        }

        public DistrictVM GetById(int id)
        {
            var data = db.Districts.Where(a => a.Id == id).Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId })
                .SingleOrDefault();
            return data;
        }
    }
}
