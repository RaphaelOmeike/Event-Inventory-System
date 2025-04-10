using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Repositories;

namespace Infrastructure.Implementations.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UploadToFileSystemAsync(ICollection<FileOnFileSystemModel> files)
        {
            await _context.FilesOnFileSystem.AddRangeAsync(files);
        }
        public void UploadToFileSystem(FileOnFileSystemModel file)
        {
            _context.FilesOnFileSystem.Add(file);
        }

        public async Task<FileStreamResult?> GetFileFromFileSystemAsync(int id)
        {
            var file = await _context.FilesOnFileSystem.FirstOrDefaultAsync(x => x.Id == id);
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return new FileStreamResult(memory, file.FileType)
            {
                FileDownloadName = file.Name + file.Extension
            };
        }

        public async Task DeleteFileFromFileSystem(int id)
        {
            var file = await _context.FilesOnFileSystem.FirstOrDefaultAsync(x => x.Id == id);
            if (file == null) return;
            if (File.Exists(file.FilePath))
            {
                File.Delete(file.FilePath);
            }
            _context.FilesOnFileSystem.Remove(file);
            _context.SaveChanges();
        }
        public async Task UploadToDatabaseAsync(ICollection<FileOnDatabaseModel> files)
        {
            await _context.FilesOnDatabase.AddRangeAsync(files);
        }
        public void UploadToDatabase(FileOnDatabaseModel file)
        {
            _context.FilesOnDatabase.Add(file);
        }

        public async Task<FileContentResult?> GetFileFromDatabaseAsync(int id)
        {
            var file = await _context.FilesOnDatabase.FirstOrDefaultAsync(x => x.Id == id);
            if (file == null) 
                return null;
            return new FileContentResult(file.Data, file.FileType)
            {
                FileDownloadName = file.Name + file.Extension
            };
        }
        public async Task DeleteFileFromDatabase(int id)
        {
            var file = await _context.FilesOnDatabase.FirstOrDefaultAsync(x => x.Id == id);
            if (file == null) return;
            _context.FilesOnDatabase.Remove(file);
            _context.SaveChanges();
        }
    }
}
