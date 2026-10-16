using Azure.Storage.Blobs; // CS0246 fix
using Azure.Storage.Blobs.Models; // CS0246 fix

namespace RaceDayApi.Services
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string containerName);
    }

    public class AzureBlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("AzureBlobStorage") ?? "UseDevelopmentStorage=true";
            _blobServiceClient = new BlobServiceClient(connStr);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            PublicAccessType

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var blobClient = containerClient.GetBlobClient(fileName);

            using var stream = file.OpenReadStream();
            BlobHttpHeaders

            return blobClient.Uri.ToString();


        }
    }
}
