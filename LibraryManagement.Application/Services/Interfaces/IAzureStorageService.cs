using LibraryManagement.Utils.Enums;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IAzureStorageService
    {
        ///// <summary>
        ///// This method handles the removal of images from the AzureStorage
        ///// </summary>
        ///// <param name="imageName">The full or partial name of the image, usually a Guid</param>
        ///// <param name="occurrence">How many occurences should be removed (Occurrence.Once to remove only the first occurence)</param>
        ///// <returns>A boolean indicating if the deletion was successful</returns>
        //Task<bool> DeleteOccurrencesAsync(string imageName, Occurrence occurrence = Occurrence.Multiple);

        ///// <summary>
        ///// This method retrives the urls of the images associated with the provided image name, usually a Guid
        ///// </summary>
        ///// <param name="imageName">The full or partial name of the image, usually a Guid</param>
        ///// <returns>An enumeration of strings representing te images urls</returns>
        //Task<IEnumerable<string>> GetImagesByNameAsync(string imageName);

        ///// <summary>
        ///// This method retrives the url of the image associated with the provided image name, usually a Guid
        ///// </summary>
        ///// <param name="imageName">The full or partial name of the image, usually a Guid</param>
        ///// <returns>A string representing the url of the image</returns>
        //Task<string> GetImageByNameAsync(string imageName);

        ///// <summary>
        ///// This method handles the uploading of a enumeration of images
        ///// </summary>
        ///// <param name="images">The image enumeration in base64 format</param>
        ///// <param name="imageName">A component of the final images names, usually a Guid</param>
        ///// <returns>An enumeration of strings representing the partial url that will be stored in the database</returns>
        //Task<IEnumerable<string>> UploadAsync(IEnumerable<string> images, string imageName);

        ///// <summary>
        ///// This method handles the uploading of a image
        ///// </summary>
        ///// <param name="image">The image in base64 format</param>
        ///// <param name="imageName">A component of the final image name, usually a Guid</param>
        ///// <param name="counter">Used only when adding multiple images associated to the same image name</param>
        ///// <returns>A string representing the partial url that will be stord in the db</returns>
        //Task<string> UploadAsync(string image, string imageName, int counter = 0);

        ///// <summary>
        ///// This method handles the updating of an image
        ///// </summary>
        ///// <param name="input">The image in base64 format</param>
        ///// <param name="imageName">A component of the final images names, usually a Guid</param>
        ///// <param name="counter">An integer representing the position of the image that will be replaced</param>
        ///// <returns>A string representing the partial url that will be stord in the db</returns>
        //Task<string> UpdateImageAsync(string input, string imageName, int counter = 0);

        ///// <summary>
        ///// This method handles the updating of an enumeration of images
        ///// </summary>
        ///// <param name="input">The image enumeration in base64 format</param>
        ///// <param name="imageName">>A component of the final images names, usually a Guid</param>
        ///// <returns>An enumeration of strings representing the partial url that will be stored in the database</returns>
        //Task<IEnumerable<string>> UpdateImagesAsync(IEnumerable<string> input, string imageName);
    }
}
