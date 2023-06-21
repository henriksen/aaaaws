using Microsoft.Identity.Client;

var app = PublicClientApplicationBuilder.Create("71c191b7-925f-4677-88c6-31a17c85a291")
    .WithAuthority(AzureCloudInstance.AzurePublic, "a1c5bee8-9e19-44cb-9f07-b94b279890ab")
    .WithRedirectUri("http://localhost")
    .Build();

var result = await app.AcquireTokenWithDeviceCode(new[] { "User.Read.All" }, deviceCodeResult =>
    {
        Console.WriteLine(deviceCodeResult.Message);
        return Task.CompletedTask;
    }).ExecuteAsync();

Console.WriteLine("Access Token: " + result.AccessToken);