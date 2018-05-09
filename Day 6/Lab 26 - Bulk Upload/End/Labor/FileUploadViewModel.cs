using Microsoft.AspNetCore.Http;

namespace Labor
{
    public class FileUploadViewModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}