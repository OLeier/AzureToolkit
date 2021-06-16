using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
#if V11
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
#endif
using Azure.Storage.Blobs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers
{
	[Route("api/[controller]")]
	public class ImagesController : Controller
	{
		private readonly BlobContainerClient _container;

#if V11
		private readonly CloudBlobContainer _container;

		// In a production application, you wouldn't hard code these values, you'd most likely read them from a configuration file. We're just keeping things simple.
		private const string storageAccountName = "azuretkstorageoleier";
		private const string accessKey = "ZzqiuHalCkc9FUILTZ6JZ4Be1Z3kNgsBw1siCvGMOjPY+kLvtS5B7rXCkdlSUepqJ8vnPjWmaRAy5lCqvmjuXw==";
#endif
		private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=azuretkstorageoleier;AccountKey=ZzqiuHalCkc9FUILTZ6JZ4Be1Z3kNgsBw1siCvGMOjPY+kLvtS5B7rXCkdlSUepqJ8vnPjWmaRAy5lCqvmjuXw==;EndpointSuffix=core.windows.net";

		private readonly AzureToolkitContext _context;

		private string ConnectionString
		{
			get
			{
				// https://docs.microsoft.com/de-de/azure/storage/blobs/storage-quickstart-blobs-dotnet
				//Console.WriteLine("Azure Blob Storage v12 - .NET quickstart sample\n");

				// Retrieve the connection string for use with the application. The storage
				// connection string is stored in an environment variable on the machine
				// running the application called AZURE_STORAGE_CONNECTION_STRING. If the
				// environment variable is created after the application is launched in a
				// console or with Visual Studio, the shell or application needs to be closed
				// and reloaded to take the environment variable into account.
				//string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
				return ImagesController.connectionString;
			}
		}

		private string ContainerName
		{
			get { return "savedimages"; }
		}

		public ImagesController(AzureToolkitContext context)
		{
			_context = context;

			// Get a reference to a container named "sample-container" and then create it
			this._container = new BlobContainerClient(this.ConnectionString, this.ContainerName);

#if V11
			var storageAccount = new CloudStorageAccount(
				new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
						ImagesController.storageAccountName,
						ImagesController.accessKey),
				   true);
			// Create a blob client.
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			_container = blobClient.GetContainerReference("savedimages");
#endif
		}

		[HttpPost]
		public async Task<IActionResult> PostImage([FromBody] ImagePostRequest request)
		{
			HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(request.URL);
			HttpWebResponse aResponse = (await aRequest.GetResponseAsync()) as HttpWebResponse;

			// Get a reference to a blob named "sample-file" in a container named "sample-container"
			string blobName = $"{request.Id}.{request.EncodingFormat}";
			BlobClient blockBlob = this._container.GetBlobClient(blobName);

			using (var stream = aResponse.GetResponseStream())
			{
				await blockBlob.UploadAsync(stream);
			}

#if V11
			//Upload Image
			CloudBlockBlob blockBlob = _container.GetBlockBlobReference($"{request.Id}.{request.EncodingFormat}");

			using (var stream = aResponse.GetResponseStream())
			{
				await blockBlob.UploadFromStreamAsync(stream);
			}
#endif

			//Save metadata
			var savedImage = new SavedImage()
			{
				UserId = request.UserId,
				Description = request.Description,
				StorageUrl = blockBlob.Uri.ToString(),
				Tags = new List<SavedImageTag>()
			};

			foreach (var tag in request.Tags)
			{
				savedImage.Tags.Add(new SavedImageTag() { Tag = tag });
			}

			_context.Add(savedImage);
			_context.SaveChanges();

			return Ok();
		}

		[HttpGet("{userId}")]
		public IActionResult GetImages(string userID)
		{
			var images = _context.SavedImages.Where(image => image.UserId == userID);
			return Ok(images);
		}

		[HttpGet("search/{userId}/{term}")]
		public IActionResult SearchImages(string userId, string term)
		{
			string searchServiceName = "azuretoolkitsearch-oleier";
			string queryApiKey = "DE7074C6C17307AFACFF50B42D642E2A";
			string searchServiceIndexName = "azuresql-index-description"; // the name of the index you created on the SavedImages table

			using var indexClient = new SearchIndexClient(searchServiceName, searchServiceIndexName, new SearchCredentials(queryApiKey));
			var parameters = new SearchParameters() { Filter = $"UserId eq '{userId}'" };
			DocumentSearchResult<SavedImage> results = indexClient.Documents.Search<SavedImage>(term, parameters);

			return Ok(results.Results.Select((savedImage) => savedImage.Document));
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
