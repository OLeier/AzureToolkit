using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;
using System.Threading.Tasks;
using WebApplicationBasic.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationBasic.Controllers
{
	[Route("api/[controller]")]
	public class ImagesController : Controller
	{
		private CloudBlobContainer _container;

		// In a production application, you wouldn't hard code these values, you'd most likely read them from a configuration file. We're just keeping things simple.
		private const string storageAccountName = "azuretkstorageoleier";
		private const string accessKey = "ZzqiuHalCkc9FUILTZ6JZ4Be1Z3kNgsBw1siCvGMOjPY+kLvtS5B7rXCkdlSUepqJ8vnPjWmaRAy5lCqvmjuXw==";

		private AzureToolkitContext _context;

		public ImagesController(AzureToolkitContext context)
		{
			_context = context;
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
			//Upload Image
			CloudBlockBlob blockBlob = _container.GetBlockBlobReference($"{request.Id}.{request.EncodingFormat}");

			HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(request.URL);
			HttpWebResponse aResponse = (await aRequest.GetResponseAsync()) as HttpWebResponse;

			var stream = aResponse.GetResponseStream();
			await blockBlob.UploadFromStreamAsync(stream);
			stream.Dispose();

			//Save metadata
			var savedImage = new SavedImage();
			savedImage.UserId = request.UserId;
			savedImage.Description = request.Description;
			savedImage.StorageUrl = blockBlob.Uri.ToString();
			savedImage.Tags = new List<SavedImageTag>();

			foreach (var tag in request.Tags)
			{
				savedImage.Tags.Add(new SavedImageTag() { Tag = tag });
			}

			_context.Add(savedImage);
			_context.SaveChanges();

			return Ok();
		}
	}

	public class ImagePostRequest
	{
		public string UserId { get; set; }
		public string Description { get; set; }
		public string[] Tags { get; set; }
		public string URL { get; set; }
		public string Id { get; set; }
		public string EncodingFormat { get; set; }
	}
}
