 
namespace NeuroAssistWeb.Services
{
    public class UploadFileService
    {
        public async Task<List<string>> UploadFile(List<IFormFile> scans)
        {
            var res = new List<string>();

            foreach (var file in scans)
            {
                var date = DateTime.Now.Date;
                var folderName = Path.Combine("wwwroot", "storage", $"{date.Day}-{date.Month}-{date.Year}");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                
                if(!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                var fileName = $"{Guid.NewGuid().ToString("N")}_." + file.ContentType.Substring(6);
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                res.Add(dbPath);
            }

            return res;
        }
    }
}
