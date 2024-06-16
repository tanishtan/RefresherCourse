using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse.Ef
{
    [Table(name: "Categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string CategoryName { get; set; } = "";

        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; }=new List<Product>();  
    }
    [Table(name:"Products")]
    [PrimaryKey("ProductId")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Precision(precision:9,scale:3)]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}
