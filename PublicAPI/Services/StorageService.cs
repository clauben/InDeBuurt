using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PublicAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Services
{
	public class StorageService : IStorageService
	{
		private readonly BlobServiceClient _blobServiceClient;
		private readonly IConfiguration _configuration;

		public StorageService(BlobServiceClient blobServiceClient, IConfiguration configuration)
		{
			_blobServiceClient = blobServiceClient;
			_configuration = configuration;
		}

		public void Upload(IFormFile formFile)
		{
			//Uri BlobUri = new Uri("https://" + idbopslag + ".blob.core.windows.net/" idb + "/" + formFile.FileName);
			var containerName = _configuration.GetSection("Storage:ContainerName").Value;

			var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			var blobClient = containerClient.GetBlobClient(formFile.FileName);

			using var stream = formFile.OpenReadStream();
			var value = blobClient.Upload(stream, true).Value;
		}
	}
}
