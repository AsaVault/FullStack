using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace BookWatch.Data
{
    public interface IBookWatchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddEntity(object model);

        bool SaveAll();
        
    }
}