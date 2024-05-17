using Microsoft.EntityFrameworkCore;

namespace Graphics_Asp_MVC.Models
{
    public class IndexOfForms
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool active { get; set; }

        
        //public virtual ICollection<FileUploadModel> FileDetails { get; set;}
    }
}
