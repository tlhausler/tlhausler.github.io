using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTitle45MCA.ViewModels
{
    public class Title45ViewModel
    {
        // class that stores information gathered from database via the context. 
        public String SelectedTitle { get; set; }
        public List<SelectListItem> SelectListTitle { get; set; }
        public String SelectedChapter { get; set; }
        public List<SelectListItem> SelectListChapter { get; set; }
        public String SelectedPart { get; set; }
        public List<SelectListItem> SelectListPart { get; set; }
        public String SelectedSection { get; set; }
        public List<SelectListItem> SelectListSection { get; set; }
        public String SelectedContent { get; set; }
        
    }
}
