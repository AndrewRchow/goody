namespace Goody.Web.Models.Requests
{
    public class FileUploadAddRequest
    {
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string ServerFileName { get; set; }
        public string ModifiedBy { get; set; }
    }
}