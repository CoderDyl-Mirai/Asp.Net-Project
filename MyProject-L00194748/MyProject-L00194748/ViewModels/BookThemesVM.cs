using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace MyProject_L00194748.ViewModels
{
    public class BookThemesVM
    {
        public int BookDetailsId { get; set; }
        public string BookName { get; set; }
        public List<int> SelectedThemesIds { get; set; } = new();
        public List<SelectListItem> Themes { get; set; } = new();
    }
}
