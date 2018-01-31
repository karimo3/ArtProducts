using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Orders> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                     .Include(o => o.Items)
                     .ThenInclude(i => i.Product)
                     .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        public IEnumerable<Orders> GetAllOrdersByUser(string username, bool includeItems)
        {

            if (includeItems)
            {
                return _ctx.Orders
                     .Where(o => o.User.UserName == username)
                     .Include(o => o.Items)
                     .ThenInclude(i => i.Product)
                     .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        //get a list of all the products
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get All Products was called");
                return _ctx.Products
                            .OrderBy(p => p.Title)
                            .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Orders GetOrderById(string username, int id)
        {
            return _ctx.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .Where(o => o.Id == id && o.User.UserName == username)
                        .FirstOrDefault();
        }

        //get products by category, ask user to pass us in the category that they want
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                        .Where(p => p.Category == category)
                        .ToList();
        } 


        //save changes the number of rows affected. save works if the number of rows affected is greater than zero
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
