using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;

namespace readapi.Pages
{
    public class UsersModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        public readonly List<string> UserNames = new();
        public UsersModel(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        public async Task OnGet()
        {
            var users = await _graphServiceClient.Users.Request().GetAsync();
            foreach (var user in users)
            {
                UserNames.Add(user.DisplayName);
            }
        }
    }
}
