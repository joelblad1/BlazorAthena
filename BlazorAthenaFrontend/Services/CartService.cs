namespace BlazorAthenaFrontend.Services
{
    using BlazorAthenaFrontend.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CartService
    {
        private readonly HttpClient httpClient;

        public CartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Product> SelectedProducts { get; set; } = new List<Product>();

        public async Task AddProductToCartAsync(Product chosenProduct)
        {
        
            SelectedProducts.Add(chosenProduct);
        }

    
        private async Task<Product> FetchProductAsync(int productId) //Not being used?
        {
            try
            {
                // Make an API request to get product information based on productId
                var product = await httpClient.GetFromJsonAsync<Product>($"https://localhost:7088/api/Product/{productId}");
                return product;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error fetching product: {ex.Message}");
                throw;
            }
        }

    }
}
