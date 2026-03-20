using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Models
{
    public class BookThemes
    {
        [Key]
        public int BookDetailsId { get; set; }
        public BookDetails? BookDetails { get; set; }

        public int ThemesId { get; set; }
        public Themes Themes { get; set; }
    }
}
