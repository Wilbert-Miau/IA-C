using System.ComponentModel.DataAnnotations;

namespace IACAST_WEB.Models
{
    public class Hosts
    {
        public int Id { get; set; }

        [Required]

        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }
      
    }
}
