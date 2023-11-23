using AthenaResturantWebAPI.Data.Context;
using AthenaResturantWebAPI.Services;
using BlazorAthena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthenaResturantWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

       private readonly ProductServices _productServices;
        
    public ProductController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet(Name = "GetProductList")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var listOfProducts = _productServices.GetProducts();

            if (listOfProducts == null)
            {
                return NotFound(); // Or any other appropriate HTTP status code
            }

            return Ok(listOfProducts);
        }



    }
}
