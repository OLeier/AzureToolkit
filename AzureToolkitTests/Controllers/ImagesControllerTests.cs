using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers.Tests
{
	[TestClass()]
	public class ImagesControllerTests
	{
		private static AzureToolkitContext GetAzureToolkitContext()
		{
			var connection = @"Server=tcp:azuretoolkit-oleier.database.windows.net,1433;Initial Catalog=azuretoolkit;Persist Security Info=False;Integrated Security=true;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			var builder = new SqlConnectionStringBuilder(connection);
			var optionsBuilder = new DbContextOptionsBuilder<AzureToolkitContext>();
			optionsBuilder.UseSqlServer(builder.ConnectionString);
			var context = new AzureToolkitContext(optionsBuilder.Options);
			return context;
		}

		[TestMethod()]
		public void ImagesControllerTest()
		{
			AzureToolkitContext context = GetAzureToolkitContext();
			var controller = new ImagesController(context);
			Assert.IsNotNull(controller);
		}

		[TestMethod()]
		public void PostImageTest()
		{
			AzureToolkitContext context = GetAzureToolkitContext();
			var controller = new ImagesController(context);

			var request = new ImagePostRequest()
			{
				URL = new Uri("https://azuretkstorageoleier.blob.core.windows.net/savedimages/D30DFA0F40F3410C282A831D55AF58D9792C225F.jpeg"),
				EncodingFormat = "jpg",
				Id = Guid.NewGuid().ToString()
			};
			Task<IActionResult> task = controller.PostImage(request);
			task.Wait();
		}

		[TestMethod()]
		public void GetImagesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SearchImagesTest()
		{
			Assert.Fail();
		}
	}
}