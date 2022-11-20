using DashBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace DashBoard.DAL.Data
{
    public class DbContainer:DbContext
    {
        public DbContainer(DbContextOptions<DbContainer>options)
            :base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<District> Districts{ get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=MOAZ\\SQLEXPRESS ; database=DepDb ; integrated security=true");
        //}
    }
}
