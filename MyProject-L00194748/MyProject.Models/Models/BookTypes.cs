using System.ComponentModel.DataAnnotations;

namespace MyProject.Models.Models
{
    public class BookTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
