namespace Graphics_Asp_MVC.Models
{
    public class IndexOfForms : FileModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string FilePath { get; set; }
        public bool active { get; set; }
    }
}
