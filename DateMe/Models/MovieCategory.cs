using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{
    public class MovieCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
