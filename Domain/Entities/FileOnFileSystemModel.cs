using Domain.Common;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class FileOnFileSystemModel : FileModel
    {
        public string FilePath { get; set; } = null!;

        public async static Task<FileOnFileSystemModel> Create(IFormFile file, string basePath, string? desc)
        {
            bool basePathExists = Directory.Exists(basePath);

            if (!basePathExists)
                Directory.CreateDirectory(basePath);

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var filePath = Path.Combine(basePath, file.FileName);
            var extension = Path.GetExtension(file.FileName);
            if (File.Exists(filePath))
                return null;
                //throw exception probably
           
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileModel = new FileOnFileSystemModel
            {
                CreatedOn = DateTime.UtcNow,
                FileType = file.ContentType,
                Extension = extension,
                Name = fileName,
                Description = desc,
                FilePath = filePath
            };
            return fileModel;
            
        }
    }
}
