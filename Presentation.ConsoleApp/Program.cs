using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sebas\Documents\Education\C#\SQLDataBaseConsoleApp\Infrastructure\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<MenuService>();
    
}).Build();

builder.Start();
var startProgram = new MenuService();
startProgram.ShowMainMenu();