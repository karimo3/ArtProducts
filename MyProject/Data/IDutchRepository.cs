using System.Collections.Generic;
using MyProject.Data.Entities;

namespace MyProject.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Orders> GetAllOrders(bool includeItems);

        IEnumerable<Orders> GetAllOrdersByUser(string username, bool includeItems);
        Orders GetOrderById(string username, int id);

        bool SaveAll();

        void AddEntity(object model);
        
    }
}