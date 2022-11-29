using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace ProjectView.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpclientfactory)
        {
            _logger = logger;
            _httpClientFactory = httpclientfactory;

            _ = OnGet();
        }

        public async Task OnGet()
        {
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Post,
            "https://localhost:7161/api/Home/Search");

            var data = new StringContent(JsonSerializer.Serialize(new
            {
                Name = "a",
                MinPrice = 1,
                MaxPrice = 1,
                PageIndex = 1,
                ElementInPage = 1
            }));


            data.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpRequestMessage.Content = data;

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var esempio = await JsonSerializer.DeserializeAsync
                    <object>(contentStream);
            }
        }
    }
}