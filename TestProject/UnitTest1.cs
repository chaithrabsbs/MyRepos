using System;
using Xunit;
using ProductWebAPI;
using ProductWebAPI.Models;
using ProductWebAPI.Controllers;
using ProductWebAPI.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TestMyProject
{
    public class UnitTest1
    {

        [Fact]
        public void CheckforProductFound()
        {
            //try
            //{ 
            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(databaseName: "ProductDb");
            var entityContext = new ProductDbContext(optionsBuilder.Options);
            AddProduct productinfo = new AddProduct();
            productinfo.Products = new System.Collections.Generic.List<Products>();
            productinfo.Products.Add(new Products
            {
                Price = 2000,
                ProductProperties = "Test",
                ProductType = "TestType",
                StoreAddress = "Test data"

            });
            HomeController controller = new HomeController(entityContext);

            //var Price = 100;
            //var ProductProperties = "Test";
            //var ProductType = "Testtype";
            //var StoreAddress = "Bangalore";

            controller.InsertProducts(productinfo);
            var min_price = 1000;
            var max_price = 30000;
            var result = controller.GetProducts(max_price, min_price);
            var flag = (result.Count > 0);

            //Assert
            Assert.True(flag);

            //ExceptionHandling if Product not Found
            //    if (flag)
            //    {
            //        Assert.True(flag);

            //    }
            //    else
            //    {
            //        throw new HttpResponseException("Record Not Found");

            //    }
            //}
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(String.Concat(ex.StackTrace, ex.Message));
            //    }


        }


        [Fact]
        public void CheckforProductNotFound()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(databaseName: "ProductDb");
            var entityContext = new ProductDbContext(optionsBuilder.Options);
            AddProduct productinfo = new AddProduct();
            productinfo.Products = new System.Collections.Generic.List<Products>();
            productinfo.Products.Add(new Products
            {
                Price = 200,
                ProductProperties = "Test",
                ProductType = "TestType",
                StoreAddress = "Test data"

            });
            HomeController controller = new HomeController(entityContext);
            controller.InsertProducts(productinfo);
            var minimum_price = 3000;
            var maximum_price = 30000;
            var result = controller.GetProducts(maximum_price, minimum_price);
            var flag = (result.Count > 0);

            //Assert
            Assert.False(flag);

        }
    }

    }

