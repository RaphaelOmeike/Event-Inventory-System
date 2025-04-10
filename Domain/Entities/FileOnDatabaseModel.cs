using Domain.Common;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class FileOnDatabaseModel : FileModel
    {
        public byte[] Data { get; set; } = null!;
        public async static Task<FileOnDatabaseModel> Create(IFormFile file, string? desc)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var fileModel = new FileOnDatabaseModel
            {
                CreatedOn = DateTime.UtcNow,
                FileType = file.ContentType,
                Extension = extension,
                Name = fileName,
                Description = desc
            };
            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                fileModel.Data = dataStream.ToArray();
            }
            return fileModel;
        }
    }
}
