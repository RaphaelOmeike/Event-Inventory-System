using Domain.Common;

namespace Domain.Entities
{
    public class FileOnDatabaseModel : FileModel
    {
        public byte[] Data { get; set; } = null!;
    }
}
