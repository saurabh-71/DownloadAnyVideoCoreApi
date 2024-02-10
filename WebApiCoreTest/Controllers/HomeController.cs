using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static WebApiCoreTest.Models.ModelApi;
namespace WebApiCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://fb-video-reels.p.rapidapi.com/smvd/get/all?url=";

        //string baseurl = "https%3A%2F%2Fwww.facebook.com%2Freel%2F975590503451951&filename=Test%20video";
        string baseurl = "";
        HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Index(string newurl="")
        {
            url += newurl != "" ? newurl : baseurl;

            Rootobject rootobjects = new Rootobject();

            // Create an HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                // Add headers
                request.Headers.Add("X-RapidAPI-Key", "f11d3bf5e0msh55e547b3125d93ep104f12jsnf1e72f734d99");
                request.Headers.Add("X-RapidAPI-Host", "fb-video-reels.p.rapidapi.com");

                // Send the request and await the response
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a List<Rootobject>
                    var data = JsonConvert.DeserializeObject<Rootobject>(result);

                    if (data != null)
                    {
                        rootobjects = data;
                    }
                }
                else
                {
                    // Handle failed response
                    Console.WriteLine("Error getting data: " + response.StatusCode);
                }
            }

            
            return View(rootobjects);
        }

    }
}
