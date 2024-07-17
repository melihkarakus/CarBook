using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogWithAuthorListViewComponents : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3BlogWithAuthorListViewComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5210/api/Blogs/GetLast3BlogWithAuthors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthorsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
