using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_McDougal.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public string? Title { get; set; }  // Allow null

        [Required]
        [Range(1888, 2100)]
        public int Year { get; set; }

        public string? Director { get; set; }  // Allow null
        public string? Rating { get; set; }    // Allow null

        public bool Edited { get; set; } = false;

        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }

        public virtual Category? Category { get; set; }
    }
}
