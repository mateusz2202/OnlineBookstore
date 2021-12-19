using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineBookstore.Entities;
using OnlineBookstore.Exceptions;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineBookstore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly OnlineBookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public CustomerService(ILogger<CustomerService> logger, OnlineBookstoreDbContext dbContext, IMapper mapper, IPasswordHasher<Customer> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public ICollection<CustomerDTO> GetAll()
        {
            var customers = _dbContext.Customers
                .Include(a=>a.Address)     
                .Include(a=>a.Role)
                .ToList();
            var customerDTO = _mapper.Map<List<CustomerDTO>>(customers);
            return customerDTO;
        }
        public CustomerDTO GetById(int id)
        {
            var customer = _dbContext.Customers
                .Include(a=>a.Address)
                .Include(a => a.Role)
                .Where(a => a.Id == id).FirstOrDefault();
            if (customer == null)
                throw new NotFoundException("Customer not found");
            var customerDTO=_mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }
        public void Create(RegisterCustomerDTO dto)
        {
            var customer = new Customer()
            {
                FisrtName= dto.FisrtName,
                LastName= dto.LastName,
                Email= dto.Email,
                Phone= dto.Phone,
                Nationality= dto.Nationality,
                DateOfBirth= dto.DateOfBirth,              
                RoleId=dto.RoleId,
            };
            var hashedPassword=_passwordHasher.HashPassword(customer,dto.Password);
            customer.PasswordHash = hashedPassword;
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }

        public string GenerateToken(LoginDTO loginDTO)
        {
            var customer = _dbContext.Customers.Include(a => a.Role).Where(x => x.Email == loginDTO.Email).FirstOrDefault();
            if (customer is null) throw new BadLoginException("Invalid email or password");
            var result=_passwordHasher.VerifyHashedPassword(customer,customer.PasswordHash,loginDTO.Password);
            if (result == PasswordVerificationResult.Failed) throw new BadLoginException("Invalid email or password");
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,customer.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{customer.FisrtName} {customer.LastName}"),
                new Claim(ClaimTypes.Role,customer.Role.Name),
                new Claim(ClaimTypes.Email,customer.Email),
                new Claim(ClaimTypes.DateOfBirth,customer.DateOfBirth.ToString("yyyy-MM-dd"))
            };
            if(!string.IsNullOrEmpty(customer.Nationality)) claims.Add(new Claim(ClaimTypes.Country,customer.Nationality));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);
            var tokenHandler=new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
