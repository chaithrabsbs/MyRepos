using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebAPI.Models
{
    [Table("Product")]
    public class Products
    {
        public int Id { get; set; }

        public string ProductType { get; set; }

        public string ProductProperties { get; set; }

        public int Price { get; set; }

        public string StoreAddress { get; set; }
    }
}
