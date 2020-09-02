using BookWatch.Data.Entities;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Data
{
    public class BookWatchSeeder
    {
        private readonly BookWatchContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public BookWatchSeeder(BookWatchContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Product.Any())
            {
                // Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Product.AddRange(products);

                var order = _ctx.Order.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                      Product = products.First(),
                      Quantity = 5,
                      UnitPrice = products.First().Price
                    }
                  };
                }

                _ctx.SaveChanges();
            }
        }
    }
}

