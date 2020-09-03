using BookWatch.Data.Entities;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Data
{
    public class BookWatchRepository : IBookWatchRepository
    {
        private readonly BookWatchContext _ctx;
        private readonly ILogger<BookWatchRepository> _logger;

        public BookWatchRepository(BookWatchContext ctx,
            ILogger<BookWatchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                //throw new InvalidOperationException("Failed");
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Product
                       .OrderBy(p => p.Title)
                       .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
            
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Product
                       .Where(p => p.Category == category)
                       .ToList();
        }

        public  IEnumerable<Order> GetAllOrders()
        {
            var result = _ctx.Order
                //.Include(o=>o.Items)
                //.ThenInclude(p=>p.Product)
                .ToList();
            return result;
        }

        public Order GetOrderById(int id)
        {
            var result = _ctx.Order.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
