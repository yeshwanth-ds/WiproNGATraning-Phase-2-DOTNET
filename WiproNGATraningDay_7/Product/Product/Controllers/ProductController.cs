using Microsoft.AspNetCore.Mvc;
using Product.Models;
using System.Collections.Generic; // ✅ Required for List<T>

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        // 1️⃣ Pass a single product using ViewBag
        public IActionResult SingleProductViewBag()
        {
            ProductModel product = new ProductModel
            {
                PCode = 101,
                Name = "Laptop",
                QtyInStock = 10,
                Details = "Dell Inspiron 15",
                Price = 75000
            };

            ViewBag.Product = product;
            return View();
        }

        // 2️⃣ Pass a list of 5 products using ViewBag
        public IActionResult MultipleProductsViewBag()
        {
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel { PCode = 101, Name = "Laptop", QtyInStock = 10, Details = "Dell Inspiron 15", Price = 75000 },
                new ProductModel { PCode = 102, Name = "Smartphone", QtyInStock = 20, Details = "Samsung Galaxy S21", Price = 60000 },
                new ProductModel { PCode = 103, Name = "Tablet", QtyInStock = 15, Details = "Apple iPad", Price = 45000 },
                new ProductModel { PCode = 104, Name = "Smartwatch", QtyInStock = 30, Details = "Apple Watch Series 7", Price = 30000 },
                new ProductModel { PCode = 105, Name = "Headphones", QtyInStock = 50, Details = "Sony WH-1000XM4", Price = 20000 }
            };

            ViewBag.Products = products;
            return View();
        }

        // 3️⃣ Pass a single product directly to the view
        public IActionResult SingleProductDirect()
        {
            ProductModel product = new ProductModel
            {
                PCode = 201,
                Name = "Gaming PC",
                QtyInStock = 5,
                Details = "RTX 3080, 32GB RAM, Ryzen 9",
                Price = 150000
            };

            return View(product);
        }

        // 4️⃣ Pass a list of 5 products directly to the view
        public IActionResult MultipleProductsDirect()
        {
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel { PCode = 201, Name = "Gaming PC", QtyInStock = 5, Details = "RTX 3080, 32GB RAM, Ryzen 9", Price = 150000 },
                new ProductModel { PCode = 202, Name = "Monitor", QtyInStock = 8, Details = "LG UltraGear 144Hz", Price = 35000 },
                new ProductModel { PCode = 203, Name = "Keyboard", QtyInStock = 20, Details = "Mechanical RGB", Price = 7000 },
                new ProductModel { PCode = 204, Name = "Mouse", QtyInStock = 25, Details = "Logitech G502", Price = 5000 },
                new ProductModel { PCode = 205, Name = "Chair", QtyInStock = 10, Details = "Ergonomic Gaming Chair", Price = 25000 }
            };

            return View(products);
        }
    }
}
