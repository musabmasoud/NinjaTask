using Microsoft.AspNetCore.Mvc;
using NinjaUI.Models;
using System.Text;
using System.Text.Json;

namespace NinjaUI.Controllers
{
    public class SegmentController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SegmentController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<SegmentDto> respons = new List<SegmentDto>();
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7054/api/Segment/GetAll_Segment");
                httpResponseMessage.EnsureSuccessStatusCode();
                respons.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<SegmentDto>>());
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
        public async Task<IActionResult> Add(SegmentDto segmentDto)
        {
            var client = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7054/api/Segment/Create_Segment"),
                Content = new StringContent(JsonSerializer.Serialize(segmentDto), Encoding.UTF8, "application/json"),
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<SegmentDto>();
            if (response is not null)
            {
                return RedirectToAction("Index", "Segment");
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
