using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Repositories;
using CadastrosEmpresas.API.Services;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string postegreSqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<ConnectionContext>(options => options.UseNpgsql(postegreSqlConnection));

builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();
builder.Services.AddScoped<IcompaniesService, CompaniesService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
using CadastrosEmpresas.API.Model.Domain.Dtos;
using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastrosEmpresas.API
{
    public class Program
    {
        static void Main()
        {
            string connectionString = "Host=localhost;Port=5432;Database=testesAPI;Username=postgres;Password=123456;";
            var options = new DbContextOptionsBuilder<ConnectionContext>().UseNpgsql(connectionString).Options;

            ICompaniesRepository compRep = new CompaniesRepository(new ConnectionContext(options));
            IcompaniesService compServ = new CompaniesService(compRep);

            CompaniesDto companiesDto = new CompaniesDto("EmpresaService3", "2004-10-19", "CleitinhoService", "68.209.866/0001-40", "Cerveja3");
            if (compServ.ModelS)
        }
    }
}
*/