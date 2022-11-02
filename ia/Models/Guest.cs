using System.ComponentModel.DataAnnotations;

namespace ia.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]

        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }
      
    }
}
