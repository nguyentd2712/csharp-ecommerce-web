using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebMVCrazorpages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    // public void OnGet()
    // {
    //     // Redirect to /home when the root page is accessed
    //     return Redirect("/Home");
    // }

    public void OnGet() => Redirect("/Home");
}