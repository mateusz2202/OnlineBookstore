using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineBookstore;
using OnlineBookstore.Authorization;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;
using OnlineBookstore.Middleware;
using OnlineBookstore.Models;
using OnlineBookstore.Models.Validators;
using OnlineBookstore.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddFluentValidation(); 
builder.Services.AddDbContext<OnlineBookstoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookstoretDbConnection")));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

var authenticationSetting = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSetting);
builder.Services.AddSingleton(authenticationSetting);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata= false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Authentication:JwtIssuer"],
        ValidAudience = builder.Configuration["Authentication:JwtIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtKey"]))
    };
});

builder.Services.AddScoped<IValidator<RegisterCustomerDTO>, RegisterCustomerDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomerAboutDTO>, UpdateCustomerAboutDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomerPasswordDTO>, UpdateCustomerPasswordDTOValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
builder.Services.AddScoped<IUserContextService, UserContextService>();



//builder.Services.AddTransient<OnlineBookstoreDBInitializer>();
//builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<OnlineBookstoreDBInitializer>().Seed();



var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
