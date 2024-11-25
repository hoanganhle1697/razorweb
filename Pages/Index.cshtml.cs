using Bogus;
using Entity_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Configuration;

namespace Entity_Razor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _context;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async void OnGet()
    {

    }

}
