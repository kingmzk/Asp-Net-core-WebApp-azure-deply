using Asp_Net_core_WebApp.Models;
using Asp_Net_core_WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Net_core_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();

        }
    }
}