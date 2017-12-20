using System.Collections.Generic;
using MyProject.Data.Entities;

namespace MyProject.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        bool SaveChanges();
    }
}