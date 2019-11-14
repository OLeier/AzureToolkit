using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;
using System.Threading.Tasks;

namespace WebApplicationBasic.Controllers
{
	[Route("api/[controller]")]
	public class ImagesController : Controller
	{
		private CloudBlobContainer _container;

		// In a production application, you wouldn't hard code these values, you'd most likely read them from a configuration file. We're just keeping things simple.
		private const string storageAccountName = "azuretkstorageoleier";
		private const string accessKey = "ZzqiuHalCkc9FUILTZ6JZ4Be1Z3kNgsBw1siCvGMOjPY+kLvtS5B7rXCkdlSUepqJ8vnPjWmaRAy5lCqvmjuXw==";

		public ImagesController()
		{
			CloudStorageAccount storageAccount = new CloudStorageAccount(
				new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
						ImagesController.storageAccountName,
						ImagesController.accessKey),
				   true);
			// Create a blob client.
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			_container = blobClient.GetContainerReference("savedimages");
		}

		[HttpPost]
		public async Task<IActionResult> PostImage([FromBody]ImagePostRequest request)
		{
			CloudBlockBlob blockBlob = _container.GetBlockBlobReference($"{request.Id}.{request.EncodingFormat}");
			HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(request.URL);
			HttpWebResponse aResponse = (await aRequest.GetResponseAsync()) as HttpWebResponse;
			var stream = aResponse.GetResponseStream();
			await blockBlob.UploadFromStreamAsync(stream);
			stream.Dispose();
			return Ok();
		}
	}

	public class ImagePostRequest
	{
		public string URL { get; set; }
		public string Id { get; set; }
		public string EncodingFormat { get; set; }
	}
}
