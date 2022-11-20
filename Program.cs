using DashBoard.BL;
using DashBoard.BL.Mapper;
using DashBoard.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
builder.Services.AddAutoMapper(a => a.AddProfile(new DomainProfile()));
builder.Services.AddDbContextPool<DbContainer>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDepartment,DepartmentRepository>();
builder.Services.AddScoped<IEmployee,EmployeeRepository>();
builder.Services.AddScoped<ICountry,CountryRepository>();
builder.Services.AddScoped<ICity,CityRepository>();
builder.Services.AddScoped<IDistrict,DistrictRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
