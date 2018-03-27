using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using ArtProducts.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtProducts.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
           _ctx.Database.EnsureCreated(); //make sure the database actually exist/created... only creates database if it doesnt exist

            var user = await _userManager.FindByEmailAsync("kokarim@msn.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Karim",
                    LastName = "Obaid",
                    UserName = "kokarim@msn.com",
                    Email = "kokarim@msn.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException($"Failed to create default user");
                }
            }


            if (!_ctx.Products.Any()) //call to Any() returns true if there are any Products in the database ... Select Count(Products) return true 
            {
                //Need to create Sample Data

                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json"); //in order for this to work at Runtime, we must inject the IHostingEnvironment hosting in the constructor as seen above
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products); //this adds all the products into the database 


                //more sample data...not sure why we need this...
                var order = new Orders()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    User = user,
                    Items = new List<OrderItems>()
                    {
                        new OrderItems()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                //adding the "order" to the collection as well
                _ctx.Orders.Add(order);

                //save changes to database 
                _ctx.SaveChanges();
            }

        }

    }
}
