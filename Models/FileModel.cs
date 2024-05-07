namespace Graphics_Asp_MVC.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string? UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
