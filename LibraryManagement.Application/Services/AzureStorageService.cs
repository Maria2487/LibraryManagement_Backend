using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Application.Settings;
using LibraryManagement.Utils;
using LibraryManagement.Utils.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace LibraryManagement.Application.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly AzureStorageSettings storageSettings;
        
        public AzureStorageService(IOptions<AzureStorageSettings> storageSettings)
        {
            this.storageSettings = storageSettings.Value;
        }

        public async Task<bool> DeleteOccurrencesAsync(string imageName, Occurrence occurrence = Occurrence.Multiple)
        {
            var container = new BlobContainerClient(storageSettings.BlobConnectionString, storageSettings.BlobContainerName);

            try
            {
                await foreach (var file in container.GetBlobsAsync())
                {
                    var containerName = container.Name;
                    var blobName = file.Name;

                    if (blobName.Contains(imageName))
                    {
                        await container.DeleteBlobAsync(blobName);

                        if (occurrence == Occurrence.One)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<string>> GetImagesByNameAsync(string imageName)
        {
            var container = new BlobContainerClient(storageSettings.BlobConnectionString, storageSettings.BlobContainerName);
            var imagesUrl = new List<string>();

            await foreach (var file in container.GetBlobsAsync())
            {
                var containerName = container.Name;
                var blobName = file.Name;

                if (blobName.Contains(imageName))
                {
                    string uri = container.Uri.Host;
                    string header = "https://";
                    var fullUri = $"{header}{uri}/{containerName}/{blobName}{storageSettings.SharedAccessSignature}";
                    imagesUrl.Add(fullUri);
                }
            }

            return imagesUrl;
        }

        public async Task<string> GetImageByNameAsync(string imageName)
        {
            var images = await GetImagesByNameAsync(imageName);
            
            return images.FirstOrDefault();
        }

        //public async Task<IEnumerable<string>> UploadAsync(IEnumerable<string> images, string imageName)
        //{
        //    var counter = 0;
        //    var imagesUrl = new List<string>();

        //    foreach (var image in images)
        //    {
        //        imagesUrl.Add(await UploadAsync(image, imageName, counter++));
        //    }

        //    return imagesUrl;
        //}

        //public async Task<string> UploadAsync(string image, string imageName, int counter = 0)
        //{
        //    IFormFile file = null;
        //    var imageUrl = string.Empty;

        //    try
        //    {
        //        if (IsBase64String(image))
        //        {
        //            file = ConvertBase64ToFormFile(image, imageName, counter);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception(Constants.InvalidBase64String);
        //    }

        //    try
        //    {
        //        var container = new BlobContainerClient(storageSettings.BlobConnectionString, storageSettings.BlobContainerName);
        //        var client = container.GetBlobClient(file.FileName);

        //        using (Stream? data = file.OpenReadStream())
        //        {
        //            await client.UploadAsync(data, new BlobHttpHeaders { ContentType = "image/jpeg" });
        //        }

        //        imageUrl = client.Uri.AbsoluteUri;
        //    }
        //    catch (RequestFailedException ex)
        //           when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        //    {
        //        throw new Exception(Constants.FileNameInUse);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception(Constants.ErrorWhileStoringImage);
        //    }

        //    return imageUrl;
        //}

        //TODO: Update the updateImage functionality to handle the removal of an image when updating the image list
        //public async Task<string> UpdateImageAsync(string input, string imageName, int counter = 0)
        //{
        //    if (IsBase64String(input))
        //    {
        //        await DeleteOccurrencesAsync($"{imageName}_{counter}", Occurrence.One);

        //        return await UploadAsync(input, imageName, counter);
        //    }
        //    else if (IsStorageUrl(input))
        //    {
        //        return input;
        //    }

        //    return string.Empty;
        //}

        public async Task<IEnumerable<string>> UpdateImagesAsync(IEnumerable<string> input, string imageName)
        {
            var imageList = new List<string>();

            //foreach (var image in input)
            //{
            //    imageList.Add(await UpdateImageAsync(image, imageName, input.ToList().IndexOf(image)));
            //}

            return imageList;
        }

        private bool IsBase64String(string input)
        {
            return (input.Length % 4 == 0) && Regex.IsMatch(input, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        private bool IsStorageUrl(string input)
        {
            return Regex.IsMatch(input, @"^https:\/\/[a-z]*\.blob[\w\d\s\S]*$", RegexOptions.None);
        }

        private FormFile ConvertBase64ToFormFile(string input, string name, int counter)
        {
            var bytes = Convert.FromBase64String(input);
            var stream = new MemoryStream(bytes, 0, bytes.Length);
            
            return new FormFile(stream, 0, bytes.Length, storageSettings.BlobContainerName, "image_" + name + "_" + counter + ".jpeg");
        }
    }
}
