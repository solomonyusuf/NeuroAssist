using Microsoft.AspNetCore.Components.Forms;

namespace NeuroAssist.Services
{
    public class FileConverterService
    {
        public async Task<string> ConvertImageToBase64(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            using var memoryStream = new MemoryStream();

            await stream.CopyToAsync(memoryStream);

            byte[] imageBytes = memoryStream.ToArray();

            return  Convert.ToBase64String(imageBytes);
        }
    }
}
