using DashBoard.Models;

namespace DashBoard.BL
{
    public interface IDistrict
    {
        IQueryable<DistrictVM> GetAll();
        DistrictVM GetById(int id);
    }
}
