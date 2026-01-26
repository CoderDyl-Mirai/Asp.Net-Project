using System.ComponentModel.DataAnnotations;

namespace MyProject.Models.Models
{
    public class Themes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
