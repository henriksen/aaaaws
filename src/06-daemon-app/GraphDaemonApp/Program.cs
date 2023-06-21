using Azure.Identity;
using Azure.Storage.Blobs;



//var credential = new ClientSecretCredential(config["TenantId"], config["ClientId"], config["ClientSecret"]);
var credential = new ChainedTokenCredential(
    new AzureCliCredential(),
    new DefaultAzureCredential());

var blob = new BlobServiceClient(
    new Uri("https://ndcdemostorageglenn.blob.core.windows.net"),
    credential);

var container = blob.GetBlobContainerClient("cont");

var blobs = container.GetBlobs();

foreach (var blobItem in blobs)
{
    Console.WriteLine(blobItem.Name);
}
