using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graphics_Asp_MVC.Models
{
    public class FileUploadModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public DateTime? CreatedOn { get; set; }

        //[ForeignKey("IndexOfFormsId")]
        //[DeleteBehavior(DeleteBehavior.)]
        //public int? IndexOfFormsId { get; set; }
        //public virtual IndexOfForms IndexOfForms { get; set; }
    }
}
