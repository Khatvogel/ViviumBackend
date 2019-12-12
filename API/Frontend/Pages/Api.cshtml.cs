using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages
{
    public class ApiModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("swagger");
        }
    }
}