using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Data;
using ProductWebAPI.Models;
using ProductWebAPI.Views;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HomeController : Controller
    {
        private readonly ProductDbContext productDbContext;

        public HomeController(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        

        ProductDAL productDAL = new ProductDAL();

        // GET:
        [HttpGet]
        public List<Products> GetProducts(int max_price, int min_price, string type = "", string city = "", string property = "")
        {
            ProductDAL productDAL = new ProductDAL(productDbContext);
            return productDAL.GetProducts(max_price, min_price, type, city, property);
            
        }
        [HttpPost]
        public void InsertProducts(AddProduct productinfo)
       {
            ProductDAL productDAL = new ProductDAL(productDbContext);
            productDAL.InsertProducts(productinfo);
        }

    }
}
