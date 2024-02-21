using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
namespace DateMe.Models
{
    public class Application
    {
            [Key]
            [Required]
            public int MovieId { get; set; }

            [ForeignKey("CategoryId")]
            public int CategoryId { get; set; }
            public MovieCategory? Category { get; set; }
        
            [Required]
            public string Title { get; set; }
            [Required]
            [Range(1888, int.MaxValue)]
            public int Year { get; set; } = 1888;
            public string? Director { get; set; }
            [Required]
            public string Rating { get; set; }
            [Required]
            public bool Edited { get; set; }
            public string? LentTo { get; set; }
            [Required]
            public bool CopiedToPlex { get; set; }
            [StringLength(25)]
            public string? Notes { get; set; }
    }
}
