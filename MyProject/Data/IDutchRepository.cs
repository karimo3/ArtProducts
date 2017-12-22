using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data.Entities;

namespace MyProject.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders();

        Order GetOrderById(int id);

        bool SaveAll();

        void AddEntity(object model);

        
    }
}