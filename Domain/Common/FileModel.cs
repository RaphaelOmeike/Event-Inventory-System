namespace Domain.Common
{
    public abstract class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string? Description { get; set; }
        public string? UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
