using System.Collections;

namespace Graphics_Asp_MVC.Models
{
    public class ViewModel
    {
        public IEnumerable<FormDownload> _formdownload { get; set; }
        public IEnumerable<IndexOfForms> _indexofforms { get; set; }
    }
}
