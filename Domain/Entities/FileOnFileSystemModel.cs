using Domain.Common;

namespace Domain.Entities
{
    public class FileOnFileSystemModel : FileModel
    {
        public string FilePath { get; set; } = null!;
    }
}
