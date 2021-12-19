using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;
using OnlineBookstore.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ; 
builder.Services.AddDbContext<OnlineBookstoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookstoretDbConnection")));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddTransient<OnlineBookstoreDBInitializer>();
builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<OnlineBookstoreDBInitializer>().Seed();



var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
