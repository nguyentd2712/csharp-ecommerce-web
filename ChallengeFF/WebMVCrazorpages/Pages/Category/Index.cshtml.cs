using Microsoft.AspNetCore.Mvc.RazorPages;
using CategoryLibrary;

namespace WebMVCrazorpages.Pages.Category
{
    public class IndexModel(IHttpClientFactory clientFactory) : PageModel
    {
        private readonly IHttpClientFactory httpconnect = clientFactory;

        public List<CategoryDto> Categories { get; set; } = [];

        public async Task OnGetAsync()
        {
            var client = httpconnect.CreateClient("GetCategory");
            var categories = await client.GetFromJsonAsync<List<CategoryDto>>("category"); //path on endpoint
                Categories = categories ?? [];
            
        }
    }
}
