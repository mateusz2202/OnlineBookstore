using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Authorization;
using OnlineBookstore.Entities;
using OnlineBookstore.Exceptions;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly OnlineBookstoreDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public OrderService(ILogger<OrderService> logger, OnlineBookstoreDbContext dbContext, IUserContextService userContextService, IAuthorizationService authorizationService, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public ICollection<OrderDTO> GetAll()
        {
            var orders = _dbContext.Orders
                .Include(a=>a.Customer)
                .Include(a=>a.OrderStatus)
                .ToList();
            var ordersDTO=_mapper.Map<List<OrderDTO>>(orders);
            return ordersDTO;
        }
        public OrderDTO GetById(int id)
        {
            var order = _dbContext.Orders
                .Include(a => a.Customer)
                .Include(a => a.OrderStatus)
                .Where(a=>a.Id == id).FirstOrDefault();
            if (order == null) throw new NotFoundException("Order not found");
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, order, new OrderOperationRequirment()).Result;
            if (!authorizationResult.Succeeded) throw new ForbidException("Forbid acces");
            var orderDTO=_mapper.Map<OrderDTO>(order);
            return orderDTO;

        }
    }
}
