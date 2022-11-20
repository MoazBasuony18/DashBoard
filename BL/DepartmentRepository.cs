using AutoMapper;
using DashBoard.DAL.Data;
using DashBoard.DAL.Entities;
using DashBoard.Models;

namespace DashBoard.BL
{
    public class DepartmentRepository : IDepartment
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public DepartmentRepository(DbContainer db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(DepartmentVM dpt)
        {
            var data = mapper.Map<Department>(dpt);   
            db.Departments.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedObj = db.Departments.Find(id);
            db.Departments.Remove(deletedObj);
            db.SaveChanges();
        }

        public IQueryable<DepartmentVM> GetAll()
        {
            var data = db.Departments.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
            return data;
        }

        public DepartmentVM GetById(int id)
        {
            var data = db.Departments.Where(a => a.Id == id).Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                .FirstOrDefault();
            return data;
        }

        public void Update(DepartmentVM dpt)
        {
            var data=mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
