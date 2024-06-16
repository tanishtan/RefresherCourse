using Microsoft.EntityFrameworkCore;
using RefresherCourse.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse.EF
{
    public class Repository
    {
        NorthwindDbContext db;
        static Func<Product, string> PrintProduct = (product) =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{product.ProductId,5} {product.ProductName,-50} {product.UnitPrice:00000.00} {product.UnitsInStock,-6}");
            return sb.ToString();
        };
        private readonly Action<Category> PrintCategory = (category) =>
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Category: ")
            .Append($"\tID: {category.CategoryId}, Name: {category.CategoryName}\n")
            .Append($"\tDescription: {category.Description}");
            if (category.Products.Count > 0)
            {
                sb.AppendLine($"\n{"Id",5} {"Product Name",-50} {"Price",7} {"Units In Stock"}");
                foreach (var product in category.Products)
                {
                    sb.AppendLine(Repository.PrintProduct(product));
                }
            }
            Console.WriteLine(sb.ToString());
        };
        public Repository()
        {
            db = new NorthwindDbContext();
        }
        public void GetCategories()
        {
            var q = db.Categories.ToList();
            q.ForEach(c => PrintCategory(c));
        }
        public void GetCategoriesWithProducts()
        {
            var q = db.Categories.Include(c => c.Products).ToList();
            q.ForEach(c => PrintCategory(c));
        }

        public void GetCategoriesWithProductsUsingJoins()
        {
            var categoriesWithProducts = from category in db.Categories
                                         join product in db.Products
                                         on category.CategoryId equals product.CategoryId into categoryProducts
                                         select new
                                         {
                                             Category = category,
                                             Products = categoryProducts
                                         };
            foreach (var item in categoriesWithProducts)
            {
                var cat = item.Category;
                foreach (var product in item.Products)
                {
                    cat.Products.Add(product);
                }
                PrintCategory(cat);
            }
        }


    }
}