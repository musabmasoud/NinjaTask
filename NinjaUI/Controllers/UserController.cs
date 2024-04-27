using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NinjaUI.Models;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NinjaUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserDto> respons = new List<UserDto>();
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7054/api/User/GetAll_User");
                httpResponseMessage.EnsureSuccessStatusCode();
                respons.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<UserDto>>());
            }
            catch (Exception ex)
            {

            }
          
            return View(respons);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Add(UserDto userDto)
        {
            var client = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7054/api/User/Create_User"),
                Content = new StringContent(JsonSerializer.Serialize(userDto), Encoding.UTF8, "application/json"),
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
            if (response is not null)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        [HttpGet]
        public IActionResult PushUserToSnapchat()
        {
            return View();
        }
    }
    
}
