using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data.Entities;

namespace MyProject.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Orders> GetAllOrders(bool includeItems);

        Orders GetOrderById(int id);

        bool SaveAll();

        void AddEntity(object model);

    }
}