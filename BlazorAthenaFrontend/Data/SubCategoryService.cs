namespace BlazorAthenaFrontend.Data
{
    public class SubCategoryService
    {
        public async Task<SubCategory[]> GetSubCategoryAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7088/api/SubCategory");
                if (response.IsSuccessStatusCode)
                {
                    var subs = await response.Content.ReadFromJsonAsync<SubCategory[]>();
                    return subs;
                }
                else
                {
                    // Handle the unsuccessful response here
                    return null;
                }
            }
        }
    }
}
