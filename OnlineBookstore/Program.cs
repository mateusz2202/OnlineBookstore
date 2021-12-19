using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
builder.Services.AddDbContext<OnlineBookstoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookstoretDbConnection")));
builder.Services.AddTransient<OnlineBookstoreDBInitializer>();
builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<OnlineBookstoreDBInitializer>().Seed();



var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
