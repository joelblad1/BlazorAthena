using AthenaResturantWebAPI.Data.Context;

namespace AthenaResturantWebAPI.Services
{
    public class ProductServices
    {
        private readonly AppDbContext _context;

        public ProductServices (AppDbContext context)
        {
            _context = context;
        }

        public List<string> GetProducts ()
        {

            var productList = _context.Products.Select(p => p.Name).ToList();

            return productList;

        }

    }
}
