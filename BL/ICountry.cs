using DashBoard.Models;

namespace DashBoard.BL
{
    public interface ICountry
    {
        IQueryable<CountryVM> GetAll();
        CountryVM GetById(int id);
    }
}
