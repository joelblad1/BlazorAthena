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

        public List<Products> SelectedProducts { get; set; } = new List<Products>();

        public async Task AddProductToCartAsync(int productId)
        {
            // Fetch product information from the API
            var product = await FetchProductAsync(productId);

            if (SelectedProducts.Contains(product) is false)
            {
                SelectedProducts.Add(product);
            }
        }

        // In CartService.cs
        private async Task<Products> FetchProductAsync(int productId)
        {
            try
            {
                // Make an API request to get product information based on productId
                var product = await httpClient.GetFromJsonAsync<Products>($"https://localhost:7088/api/Product/{productId}");
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
