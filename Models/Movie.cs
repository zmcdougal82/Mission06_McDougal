using System.ComponentModel.DataAnnotations;

namespace Mission06_McDougal.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        public required string Title { get; set; } 
        public required string Category { get; set; }
        public required string Director { get; set; }
        
        public int Year { get; set; }

        public required string Rating { get; set; }

        public bool Edited { get; set; } = false;  

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}