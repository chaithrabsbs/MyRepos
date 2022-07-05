using System;
using System.Collections.Generic;
using System.Linq;
using ProductWebAPI.Data;
using ProductWebAPI.Models;

namespace ProductWebAPI.Views
{
    public class ProductDAL
    {
        private readonly ProductDbContext productDbContext;

        public ProductDAL()
        {
        }

        public ProductDAL(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        
    
            public List<Products> GetProducts(int max_price, int min_price, string type = "", string city = "", string property = "")
            {
            try
            {
                if(min_price>0 && max_price>0)
                {
                    var products = productDbContext.products.Where(x => x.Price > min_price && x.Price < max_price || x.ProductType == type || x.StoreAddress == city || x.ProductProperties == property).ToList();
                    return products;
                    
                }
                
                else {
                    return new List<Products>();
                }
                
            }
            catch(Exception ex)
            {
                throw new System.Exception("Item not found");
            }
            }

        public void InsertProducts(AddProduct productinfo)
        {
            try
            {
                //var data = productinfo;
                AddProduct data = new AddProduct();
                data.Products = new List<Products>();
                //ProductList list = new ProductList();
                foreach(var item in productinfo.Products)
                {
                    

                    Products products = new Products();

                    products.Id = item.Id;
                    products.Price = item.Price;
                    products.ProductProperties = item.ProductProperties;
                    products.ProductType = item.ProductType;
                    products.StoreAddress = item.StoreAddress;
                    productDbContext.AddRange(products);
                    productDbContext.SaveChanges();

                }



                //Products products = new Products();
                //products.Id = productinfo.Id;
                //products.Price = productinfo.Price;
                //products.ProductProperties = productinfo.ProductProperties;
                //products.ProductType = productinfo.ProductType;
                //products.StoreAddress = productinfo.StoreAddress;
                //productDbContext.AddAsync(products);
                //productDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new System.Exception("Item not found");
            }
        }


    }
}
