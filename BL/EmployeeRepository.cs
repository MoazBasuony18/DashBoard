//using AutoMapper;
using AutoMapper;
using DashBoard.DAL.Data;
using DashBoard.DAL.Entities;
using DashBoard.Models;

namespace DashBoard.BL
{
    public class EmployeeRepository : IEmployee
    {
        private readonly DbContainer db;
        private Employee data;

        private readonly IMapper mapper;

        public EmployeeRepository(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            
            db.Employees.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedObj = db.Employees.Find(id);
            db.Employees.Remove(deletedObj);
            db.SaveChanges();
        }

        public IQueryable<EmployeeVM> GetAll()
        {
            var data = db.Employees.Select(a => new EmployeeVM
            {
                Id = a.Id,
                Address = a.Address,
                Email = a.Email,
                HireDate = a.HireDate,
                IsActive = a.IsActive,
                Name = a.Name,
                Notes = a.Notes,
                Salary = a.Salary,
                DepartmentId=a.Department.DepartmentName,
                DistrictId = a.District.DistrictName
            });
            return data;
        }

        public EmployeeVM GetById(int id)
        {
            var data = db.Employees.Where(a => a.Id == id).Select(a => new EmployeeVM
            {
                Id = a.Id,
                Address = a.Address,
                Email = a.Email,
                HireDate = a.HireDate,
                IsActive = a.IsActive,
                Name = a.Name,
                Notes = a.Notes,
                Salary = a.Salary,
                DepartmentId = a.Department.DepartmentName,
                DistrictId=a.District.DistrictName
            })
                .FirstOrDefault();
            return data;
        }

        public void Update(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
