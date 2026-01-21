using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject_L00194748.Models
{
    public class BookDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string CoverImage { get; set; }
        public int BookTypeID { get; set; }
        public BookTypes BookType { get; set; }
        public List<Themes> Themes { get; set; } = new List<Themes>();
    }
}
