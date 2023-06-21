using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Incremental.Pages
{
    [Authorize(Roles = "PowerUser")]
    public class PowerUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
