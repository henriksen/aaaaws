using Azure.Core.Diagnostics;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace DefaultIdentity.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public List<User> Users { get; set; } = new();

    public async Task OnGet()
    {
        using AzureEventSourceListener listener = new AzureEventSourceListener((e, message) =>
            {
                if (e.EventSource.Name == "Azure-Identity")
                {
                    _logger.LogWarning(message);
                }
            },
            System.Diagnostics.Tracing.EventLevel.LogAlways);
        var cred = new ChainedTokenCredential(
            new AzureCliCredential()
            , new DefaultAzureCredential());

        var credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions()
            {
                ExcludeVisualStudioCredential = true,
                Diagnostics =
                {
                    IsAccountIdentifierLoggingEnabled = true,
                },
            });

        var graphClient = new GraphServiceClient(credential);

        var result = await graphClient.Users.GetAsync();
        if (result?.Value != null)
        {
            Users = result.Value;
        }

    }

}
