namespace Graphics_Asp_MVC.Models
{
    public class FormDownload
    {
        public int Id { get; set; }
        public string? FormType { get; set; }
        public string? FormNumber { get; set; }
        public string? FormName { get; set; }
        public string? FormUrl { get; set; }
        public bool active { get; set; }
    }
}
