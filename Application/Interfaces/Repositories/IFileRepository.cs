using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces.Repositories
{
    public interface IFileRepository
    {
        Task UploadToFileSystemAsync(ICollection<FileOnFileSystemModel> files);
        void UploadToFileSystem(FileOnFileSystemModel file);
        Task<FileStreamResult?> GetFileFromFileSystemAsync(int id);
        Task DeleteFileFromFileSystem(int id);
        Task UploadToDatabaseAsync(ICollection<FileOnDatabaseModel> files);
        void UploadToDatabase(FileOnDatabaseModel file);
        Task<FileContentResult?> GetFileFromDatabaseAsync(int id);
        Task DeleteFileFromDatabase(int id);
    }
}
