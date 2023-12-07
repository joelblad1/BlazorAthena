using AthenaResturantWebAPI.Migrations;
using Newtonsoft.Json;
using System.Text;
using BlazorAthenaFrontend.Data;

namespace BlazorAthenaFrontend.Data
{
    public class ImageService
    {   
        string APIDOMAIN = Globals.APIDOMAIN;
        private readonly HttpClient httpclient;

        public async Task<SubCategory[]> GetSubCategoryAsync()
        {
            using (var httpClient = new HttpClient())
            {
                /*
                var response = await httpClient.GetAsync($"{APIDOMAIN}/SubCategory"); //TODO global variable
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
                */
                    return null;
            }
        }
        public async Task<bool> UploadImage(IFormFile image)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(image.OpenReadStream())
            {
                Headers = { ContentLength = image.Length, ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(image.ContentType) }
            }, "image", image.FileName);
            var response = await httpclient.PostAsync(APIDOMAIN+"/Image", formData);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

            /*
            HttpClient http = new HttpClient();
            var newSubCategory = new SubCategory { ID = 0, Name = name };
            var stringContent = new StringContent(JsonConvert.SerializeObject(newSubCategory), Encoding.UTF8, "application/json");

            var response = await http.PostAsync($"{APIDOMAIN}/SubCategory/", stringContent); //TODO global variable for api domain
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");

            }
            else { Console.WriteLine("failed"); }
            */

        }


        public async Task DeleteSubCategory(int id)
        {
            /*
            HttpClient http = new HttpClient();
            
            var response = await http.DeleteAsync($"{APIDOMAIN}/SubCategory/{id}"); //TODO global variable for api domain
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");

            }
            else { Console.WriteLine("failed"); }
            */
        }

         public async Task EditSubCategory(int id, string newName)
        {
            /*
            HttpClient http = new HttpClient();
            var updatedSubCategory = new SubCategory { ID = 0, Name = newName };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updatedSubCategory), Encoding.UTF8, "application/json");

            var response = await http.PutAsync($"{APIDOMAIN}/SubCategory/{id}", stringContent ); //TODO global variable for api domain
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");

            }
            else { Console.WriteLine("failed"); }
            */
        }


    }
}
