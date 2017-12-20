using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;

        public DutchRepository(DutchContext ctx)
        {
            _ctx = ctx;
        }

        //get a list of all the products
        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                        .OrderBy(p => p.Title)
                        .ToList();
        }

        //get products by category, ask user to pass us in the category that they want
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                        .Where(p => p.Category == category)
                        .ToList();
        } 


        //save changes the number of rows affected. save works if the number of rows affected is greater than zero
        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
