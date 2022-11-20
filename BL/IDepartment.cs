
using DashBoard.Models;

namespace DashBoard.BL
{
    public interface IDepartment
    {
        IQueryable<DepartmentVM> GetAll();
        void Add(DepartmentVM department);
        void Update(DepartmentVM department);
        DepartmentVM GetById(int id);
        void Delete(int id);
    }
}
