using System.ComponentModel.DataAnnotations;

namespace Application.Options
{
    public class FileStorageOptions
    {
        [Required(AllowEmptyStrings = false)]
        public string BasePath { get; init; } = null!;
    }
}
