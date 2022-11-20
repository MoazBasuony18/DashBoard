using DashBoard.Models;

namespace DashBoard.BL
{
    public interface IEmployee
    {
        IQueryable<EmployeeVM> GetAll();
        void Add(EmployeeVM employee);
        void Update(EmployeeVM employee);
        EmployeeVM GetById(int id);
        void Delete(int id);
    }
}
