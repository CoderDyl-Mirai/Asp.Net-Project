using System.ComponentModel.DataAnnotations;

namespace MyProject_L00194748.Models
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
