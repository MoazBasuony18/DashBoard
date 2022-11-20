using DashBoard.Models;

namespace DashBoard.BL
{
    public interface ICity
    {
        IQueryable<CityVM> GetAll();
        CityVM GetById(int id);

    }
}
