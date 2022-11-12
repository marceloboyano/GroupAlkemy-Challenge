using AlkemyWallet.Core.Interfaces;
using System.Text.RegularExpressions;
using static AlkemyWallet.Core.Helper.Constants;
namespace challenge.Services;

public class ImageService : IImageService
{
    public enum ImageType
    {
        Catalogue
    }

    public async Task<string> StoreImage(IFormFile imageFile, ImageType imageType)
    {
        var regex = new Regex(".*\\.jpg|.*\\.png|.*\\.pdf");

        if (!regex.IsMatch(imageFile.FileName))
        {
            var exception = new Exception(IMG_FORMAT_NOT_SUPPORTED_MESSAGE);
            throw exception;
        }

        if (imageFile.Length / 1024.0 / 1024.0 > 10)
        {
            var exception = new Exception(IMG_TOO_BIG_MESSAGE);
            throw exception;
        }

        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");

        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        var fileHeader = imageType switch
        {
            ImageType.Catalogue => "Catalogue",
            _ => "Unknown"
        };

        var guid = Guid.NewGuid();

        var filePath = $"{fileHeader}-{guid}-{imageFile.FileName}";

        using var stream = File.Create(Path.Combine(directoryPath, filePath));

        await imageFile.CopyToAsync(stream);

        return filePath;
    }
}