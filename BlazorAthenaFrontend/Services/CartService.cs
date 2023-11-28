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
            // Fetch product information from the API
            //var product = await FetchProductAsync(chosenProduct);

            //if (SelectedProducts.Contains(product) is false)
            //{
            //    SelectedProducts.Add(product);
            //}
            SelectedProducts.Add(chosenProduct);
        }

        // In CartService.cs
        private async Task<Product> FetchProductAsync(int productId)
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
